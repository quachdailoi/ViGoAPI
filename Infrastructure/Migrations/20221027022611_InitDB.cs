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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("231b4315-57d5-4aee-a86b-0f65bdfa2636")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 397, DateTimeKind.Unspecified).AddTicks(7158), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f91373ee-b45b-4dc5-96c5-0012a5fd60e9")),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    option = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
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
                name: "wallet_transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    txn_id = table.Column<string>(type: "text", nullable: false),
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
                        name: "FK_wallet_transactions_wallets_wallet_id",
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
                    driver_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_booking_detail_drivers_users_driver_id",
                        column: x => x.driver_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "affiliate_parties",
                columns: new[] { "id", "code", "CreatedAt", "CreatedBy", "DeletedAt", "name", "status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("5b8f97a6-ce35-4f3d-968a-6ea3ca9fbcf3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("9eff09da-9243-411a-a5ea-886601fe743f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6343), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0a82e67f-86e8-4fab-9a60-9cd56428e82b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6345), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("64b282b7-ed6c-449e-9f73-11dc61b2b479"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("113a8a61-88ea-46b8-bafa-653de82f827d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("95c954c4-e215-4d6b-b15c-9b652977f55b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6064), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("d59c07d3-bae8-44ef-b1f5-e52c2a787c94"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6073), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("30f477f3-2e58-4fb1-a81a-a1f83f404db8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("cb185cc4-c07b-4128-b368-c8e1bac9f033"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("c3497f3b-a6ec-4f13-8dfa-9027496d99a4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6114), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("d4fb8e3c-b333-4909-ac26-2f098b4b8b4f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6123), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("5f29f8fc-351e-42e5-87a7-d2ce8ac92249"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("89894177-19ac-489a-91ff-4a6281415dc9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("8b7e65ec-73fc-41a9-ab41-2d3c6e075724"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("577d75c3-57e6-4580-882f-fbd545901fbf"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("0dc0e311-3e0d-496f-915f-135ddf0adf0b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6169), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4578), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4624), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("f615bc51-d9f9-40ef-a6d5-7b85268f4446"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5012), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("910c2ca2-2179-4f0d-bb3c-6a968486c8fc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5020), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("17eb17bf-987c-4caf-8e52-76bce76fca9b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("43bc607b-28de-45a0-bb21-8083409c9846"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d4e6ddc2-90cd-4e0a-8d56-59d61f73b4c8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5028), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29ca06b8-6498-43e1-9fb6-f31c1edbecaa"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8eaf41a-c7c8-422a-a057-933dc885e2e3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a9e20695-c85d-4405-a7c5-5cda91ec7baf"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("3a574431-78c5-4882-a36b-a338f1dcaf23"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("10341036-5356-47a1-9981-d3d8700bd520"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5046), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7f088468-a916-488b-88f1-26561b0a5735"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6827140c-1269-4b77-a285-8cfc88e58fe2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5051), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ce39e0b9-61b9-4776-b379-d30983a753b0"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("f117dcb0-047d-4a82-9c8f-d31865c1e71e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5055), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8e3ea31d-99a1-4642-9852-5ca96ae154a9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2c2cd3d3-3b71-4408-b9a5-2a4f192275a1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e5dee065-7a05-4a05-b25d-28e3aad7529c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("84b00dcd-72bb-42c9-8f24-b1de57390410"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6f12210-3d04-4349-aad5-1194e4c25f2f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5104), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("114f4278-5223-4bb3-ac26-9382fd57f89d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("278f79e3-9812-4b11-bf6d-ee9941088d19"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5109), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("07dcb96a-bef4-4b13-a58b-c560d116b66a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("830b5dee-2b6b-4f2b-b587-cb7bb89fdb6e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5117), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bf811a1c-fe66-4caa-a03e-045e7de1599a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("23de5a50-700c-4cdc-96d6-95e544ed969f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("16adfe09-c0f5-4787-a25d-52a12133882b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4a30cfed-f990-408b-9521-616d8da347c5"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5127), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2359114b-f89f-4bf9-aede-682e1e12ee5f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("500354ae-f09b-49d6-a62a-1650d75d4fae"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68d75a43-e9d5-44c3-9ed7-2b0179b5b4ff"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dc4365b3-80e9-4aba-892e-9e218404db00"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("115e0aae-8be6-4f06-ac75-7bac581c4818"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7fbb8f5a-5cd0-4854-82d9-320addeefefd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5143), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4534851c-c0e7-4734-be9d-40607ffdf70d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3558336f-657e-4d26-b149-796726ddbea6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6d804257-c63e-4d5e-9147-b068493f7f63"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("d51c92c1-8d2f-40d9-9a79-0d70f2d2cebc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5152), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("23f40797-4011-4002-8383-acef374b30a7"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("617f0dd8-f3d4-4b9b-b05c-8f7520480ae7"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("040d44d2-914f-4a4e-8ba5-ab043e89d627"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5160), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("74c8c146-e0f7-4d57-b702-869d7022a010"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("86720efb-a40e-4e1c-b81a-62aca847762b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("967ea257-a8ad-4226-a14b-bea86ddccf10"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("31e4ec3f-38fc-4a48-9497-4d5d1560b1b8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5169), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("327c6d96-3c12-4ccf-a140-9ad2a5fd3df4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("51221101-83ed-4e9d-87d6-5fd74b9c254e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6bc38724-be4d-49ed-8ef8-98465651e28a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a480426-d61f-4a16-9a5e-406a19e44ece"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("85b955c9-4839-4714-99cf-55a8e3538683"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5183), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e4731a8d-05d6-44aa-b15f-2482afd01fc6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5185), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b67a08a4-8c7f-43e6-b79f-2e48e9587359"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5187), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b8dde96b-6d6b-473a-9602-9f8a2272db28"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("be603b97-73fb-4d3b-8dff-b76e94a2aba8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5192), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cc3d0099-0f12-4930-818f-f203b978ba9f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("49179802-90b0-47e0-9998-1bd0d49e311f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6ad88add-dc69-404d-9805-863776be96a3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d263c80c-a876-4d15-8924-0e1de0f3be7e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d77c3a73-865b-4802-83a0-45a1efd09eb4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5234), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ca90fc71-a364-4ba1-a781-33895ce732d6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6abc1bd8-fdb2-46df-9bd7-c496554cfc2f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("52e15185-944c-4d83-ad1c-41af34bafa22"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b7018252-28f5-4ee4-a8cb-a3c8e4031921"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5242), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d923f69-8c2f-4eb9-8004-edbe728c4ae8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5246), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1c1a173-4c0c-4b18-a251-795ed6dede60"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6157f2b0-38b2-4cc9-8406-0c39c7e4aa6f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5fdaecce-abfa-4be4-9b14-06e89f60c7f3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5254), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a817240-8da3-49f6-b341-13f72cdd1c6a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5256), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("48a1086c-a9f9-4413-b987-9374231793cf"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("edff500d-065e-42f4-b528-cf4889657c15"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5261), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6b3211dd-602a-4536-a2d0-ebb889e08896"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("7a402243-843c-461c-a2c7-08bc5c474a26"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("831b024b-f0cd-4777-bbaf-f89a1155cbcd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5270), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fd5ee408-3635-4a82-9c91-da8461cbc0aa"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5272), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("386460e2-40be-4194-8323-17bcf46df979"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3af853f5-475d-4c84-bde3-74de3d81bd98"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5276), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a36fcd25-77cf-4689-b1f4-ae2794d142f1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5278), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1e4cfde4-8f28-4957-8387-332b17e2283d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5281), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9ab34e37-5e9a-4d99-8a5b-fd992fe0288b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("791f8647-c356-4bfd-85a2-daeccef2735e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("f2ae17cc-c496-4168-ad5e-5d1b5bf754a8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5289), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9efc7528-e6a0-4ead-b98d-89eb51672dd0"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("bf570f4e-ce78-4869-a2c1-ec8c820a9f8b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5293), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("1e72dfd9-1d83-458f-bccb-5eab1b8aeb54"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("f1d84aa8-a398-4f22-add3-50531086b57b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5298), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eadb14e3-e2ab-475b-833f-49d8b91d0e25"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("191a96fe-e850-4660-a5f4-34a50f96b85e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5300), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("8a9c9308-263c-4e8b-a21d-6547ec0e3d2f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("af8d3f29-048d-4d8b-88cb-3e7c7842a336"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6379), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("c87f8676-b603-49c4-bf22-37bf052be88e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, new Guid("826b5d2a-c6f9-4e99-a4d9-61fa4891930b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 100", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, new Guid("72ea9473-f43c-4184-9755-876e5694c1cd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 101", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, new Guid("3ab70338-b957-4111-bff0-7c5f2512001e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 102", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, new Guid("35ff109f-622d-4f5c-ac69-10e4281c8ba7"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 103", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, new Guid("f8a743a6-279b-4bc3-af96-b3a7194f82cb"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 104", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6539), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, new Guid("cabcd907-5d60-48dd-a0c5-b5a670025d2b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 105", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, new Guid("caf6ac31-5b0f-4e23-8820-d6c69f09f698"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 106", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, new Guid("6dbcf960-7ced-4fd7-83c7-e3553a618110"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 107", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6579), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, new Guid("cd276b10-f82b-46b3-8bc8-aa9c9c64ee54"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 108", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6593), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, new Guid("abfcf529-c9cc-401b-9bfc-cce2b8c2cfcd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 109", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, new Guid("47271531-72a0-4ddb-bace-28d6934805d5"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 110", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, new Guid("f9d162e8-411d-4c95-a4d9-7808a35b3a09"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 111", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6628), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, new Guid("ad9e0998-30a5-4b97-ab42-8c841c98d85c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 112", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, new Guid("769a2c20-f927-452b-a74f-6cdca5d9d317"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 113", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6653), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, new Guid("b297569c-e0ea-4e08-936c-332d195fff97"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 114", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, new Guid("3b33f521-95de-4e68-9b61-e83429bcd99d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 115", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6676), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, new Guid("afa10bc9-f036-49a9-a85e-e8986f3cade3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 116", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, new Guid("57f928c7-2ef4-493d-b428-fd9148c2bcff"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 117", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6728), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, new Guid("8e81fca4-863b-48f0-ac14-ea6b37316857"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 118", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6740), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, new Guid("14dda895-3f45-495a-b81a-0cc00a495fc1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 119", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6752), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, new Guid("2c94ba3b-3cd0-4170-9865-1a9ef9807872"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 120", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6766), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, new Guid("7098fd4a-d16c-47ae-be60-0d5cdd800548"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 121", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, new Guid("c78500d7-fc74-464e-89ae-70dc2b940bfc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 122", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6791), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, new Guid("4049e541-fa10-4bbc-b645-c4a81fe73295"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 123", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, new Guid("944ebe9d-d1c7-4c9c-83f6-40afdefc18a4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 124", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, new Guid("41c64984-f357-4ba2-95c0-cd940cd8b10e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 125", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6828), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, new Guid("80bbd530-4875-4c28-a2b3-d180e1383550"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 126", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, new Guid("f7007171-d800-4ece-93de-804cf510da4a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 127", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, new Guid("bc63a104-cd0f-498d-ba6d-fb283125c532"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 128", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, new Guid("1f2f2039-1ad9-4482-9fe4-90915af54c13"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 129", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6950), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, new Guid("ba623bdc-d1ec-4422-9bfc-d0c987fd2de2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 130", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, new Guid("509c859d-418c-4e5c-accc-a9f7b33df8a6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 131", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, new Guid("e2a9ebfd-52ef-4d46-83d2-5a246c49c7d3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 132", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7007), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, new Guid("5e89faf9-a318-4b4c-a9c3-d6a583b18349"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 133", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, new Guid("95e5a402-b3f7-4085-bb05-3bbeef4474d9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 134", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, new Guid("d035d011-dc6f-420f-8b3d-b15040597a18"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 135", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, new Guid("47e70b33-dc90-4ded-8073-2d527a373ffd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 136", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, new Guid("c0517336-8d63-4f38-9666-0a57ecde4115"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 137", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, new Guid("37ffb501-8487-455f-a62b-049a808dc76f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 138", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, new Guid("60e43d2a-9266-46cc-ac94-dcc859a2cd9f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 139", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, new Guid("993c52ec-7c8e-46ad-9eba-1c0f37a3220a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 140", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7153), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, new Guid("8fbc9915-62ca-467f-b716-ae78cd067a28"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 141", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, new Guid("7fec64ef-2f37-4562-8993-668925b78647"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 142", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7177), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, new Guid("25ede264-2bf1-460d-9cd1-62a9abe46f93"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 143", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7188), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, new Guid("16df9b4a-199a-4305-a179-ffad49f24f5d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 144", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, new Guid("d45b6dc1-5562-487e-bb20-0ceb5b72839e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 145", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, new Guid("545fed50-4c1e-4171-8542-bbd2eb40578a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 146", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7225), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, new Guid("43cb669b-4f32-4ea8-866f-df5e3167ea1f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 147", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, new Guid("3ce2a809-cee7-4c2c-b982-5151bad7cdfe"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 148", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7251), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, new Guid("6086a408-dcea-4684-a46c-fac341ee97f3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 149", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7262), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, new Guid("01839947-84e9-4f4a-b80b-71451731d510"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 150", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, new Guid("6feeac9a-c043-4a4e-b636-f47add947a16"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 151", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7308), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, new Guid("477bd9ae-1a0c-4718-8803-6d3b3f08a481"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 152", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7323), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, new Guid("48f8f308-41fc-4702-96a5-4560806560f0"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 153", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, new Guid("0a5c701e-950d-4d1f-ae5b-07a181310e62"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 154", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, new Guid("e1796137-8644-4cb0-97f5-d580b0aaafc4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 155", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, new Guid("4fd52d51-f9d9-4adc-8932-d5242ad78d63"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 156", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7374), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, new Guid("8fb79442-619e-46c2-95ec-27dbe71e39f4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 157", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, new Guid("c0de9246-9506-4af3-9ddb-535d60f26bb3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 158", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, new Guid("8889be91-143f-4b0b-a63d-4fc0f64af97b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 159", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, new Guid("cd275f7b-9cba-495a-80f5-797c7dc3999b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 160", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, new Guid("5b6e04f3-c8cb-4efe-8c8f-9c1ff96d921a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 161", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, new Guid("cb2cc655-ea30-4f70-a55c-264997e125a7"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 162", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7468), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, new Guid("46f295a6-19f2-481e-9961-66b4f301ddea"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 163", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7480), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, new Guid("29fdd245-bc29-48be-96c9-baacc0eac0a9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 164", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, new Guid("f733f78b-2b1b-4616-ab3a-d63054cc9424"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 165", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7506), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, new Guid("52c5807f-6fc4-4b77-81a4-9cbf3ee50360"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 166", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, new Guid("a9404421-c632-42cc-b0ad-167c13e937fc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 167", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7540), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, new Guid("eb4d5ca9-6850-4294-9b27-b0054c450eb4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 168", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, new Guid("1f8150c5-3953-480b-98d7-34d7a1a63820"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 169", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7581), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, new Guid("a253fc42-40d3-44bd-ae15-2c103391c0fc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 170", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, new Guid("02428707-549e-408d-80c7-cf286eadcbd2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 171", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, new Guid("67d12c58-99ee-4e22-9dd6-bddaa17c6b61"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 172", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, new Guid("8e8ab896-bde7-4355-bdea-f861bfef696d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 173", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7659), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, new Guid("8c003f11-eb17-4933-a4e2-45f191b271cc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 174", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, new Guid("ed3a1219-a7d8-49b3-8174-ad9750ede45f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 175", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, new Guid("5025a5ed-f47d-4eac-8a54-e1f0ce29a2be"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 176", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, new Guid("6867cfaa-2760-430d-bc6a-d6dce9c698ee"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 177", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, new Guid("c4db87c5-f6a0-467b-b4aa-3ff8dd3fc89a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 178", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7763), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, new Guid("6fa2e85b-fb03-475b-bf47-bc7af432880e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 179", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, new Guid("ab24aaa4-6224-4476-81d4-f095ac495b19"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 180", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, new Guid("9ab73ad1-1feb-47b2-8b04-9c21d499a278"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 181", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, new Guid("219c45c4-9181-4d5a-b9ad-df007a12ab84"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 182", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7811), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, new Guid("a549da25-1cfa-4675-bae8-9bdb4b2cd14d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 183", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7822), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, new Guid("75dcd310-2fd6-4c01-b07d-28e4c672d265"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 184", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, new Guid("8a834c08-3247-4d1d-8e3b-e4628573092f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 185", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7848), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, new Guid("bab089b9-9b6c-4d6d-be2c-38bc5fb27a98"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 186", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7890), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, new Guid("6697b113-3571-404d-a82b-2516698867a5"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 187", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, new Guid("978c68ab-174c-461e-9014-7d041d25d3b2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 188", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7916), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, new Guid("1edd0413-f13b-4a1e-b22b-105956d222c7"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 189", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, new Guid("7c14a07d-9d87-4974-b0ba-0a95301c1200"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 190", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7939), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, new Guid("68da9971-290d-4f6e-9d07-7c18e8913c66"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 191", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, new Guid("92ea40dc-d06f-4c73-afae-506fa2d9f094"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 192", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, new Guid("cd0067a0-8cef-4945-82f1-72aeac105c02"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 193", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, new Guid("5c0c55b9-1554-4821-b8e4-b8f82a6951f1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 194", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7987), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, new Guid("5c535e62-e15a-453d-beec-d282b93524dd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 195", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(7998), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, new Guid("5f30db27-a021-4cbe-a852-937f459db1bd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 196", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8012), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, new Guid("a8ca94ea-dbe3-4461-9079-d8a2eb7ebee1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 197", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, new Guid("bcdc68bb-20bc-4588-8144-c9e1d3d0cefc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 198", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8063), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, new Guid("7611295d-898b-4495-a80c-dd0150cdcfe2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 199", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8075), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, new Guid("5fed6352-0872-41e4-b90f-40b9c36fa1ae"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 400", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, new Guid("4676ab73-2aec-4c4f-9775-6d0d9d92e99a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 401", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, new Guid("7b54fb27-2cf0-4a43-ac77-caee311f2763"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 402", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8114), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, new Guid("edcaf64a-6d91-4eb3-84cb-16f8f85bcbd4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 403", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, new Guid("a689cf1a-372b-4d78-8a61-7de655db79d2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 404", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, new Guid("0e3f371b-2fad-475c-a027-d8678897e473"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 405", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, new Guid("1669798e-8841-43de-a311-dd922bec9be5"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 406", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, new Guid("5cb23408-b6b1-4dc3-8b16-c7f562534bee"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 407", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, new Guid("6f329aba-9951-4b2e-b17e-3eb28aac4fce"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 408", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, new Guid("532b92de-7f87-4876-8b63-68b3570b93b4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 409", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, new Guid("131b2bdc-3aaa-45ae-afd7-4a7dae925d3d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 410", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8304), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, new Guid("fea1807a-b047-4f80-938f-4a66b431a179"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 411", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8318), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, new Guid("380c67cf-015c-4fac-a24d-a3868e825592"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 412", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8332), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, new Guid("1f187fb8-7dec-4ce3-8f67-f675c02f4c95"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 413", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8344), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, new Guid("2880cef7-d0e4-4869-90f7-3f5131533858"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 414", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, new Guid("a885cb8d-3ba3-4af6-9f15-14d55a223f38"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 415", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8366), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, new Guid("43142173-65b8-4d40-b409-6f5f4726ba2f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 416", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8380), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, new Guid("c47afd79-e938-4d6b-8d35-ef4888ec5e66"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 417", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8393), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, new Guid("31360b24-4218-4d88-9ca6-6a4aa236aeb5"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 418", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, new Guid("884fd755-ffb4-4a37-b235-bc01a4352822"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 419", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, new Guid("2f0215f2-73a5-4a6b-8179-3e920f1fa54c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 420", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, new Guid("9cd31843-a213-4810-a3d5-5d7235fd2d0a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 421", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, new Guid("cd074a87-103b-4f98-be54-a3139e186645"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 422", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8500), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, new Guid("ff2d56ca-8e24-4dfd-b750-ba5f9a894648"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 423", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, new Guid("8ac28ad8-5e65-4e0b-afc0-92e313f2931f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 424", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8524), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, new Guid("8345f019-b21a-435e-94d1-8846bf0204d9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 425", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, new Guid("555c8092-7000-44e9-88c7-edbfd087bf2c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 426", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, new Guid("5efd2df3-1fd9-4899-b129-e275aa7cb859"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8557), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 427", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8558), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, new Guid("6729c8a9-5d5d-4b44-9bec-8e8e20e813ea"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 428", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, new Guid("dc803265-9790-42a0-be6f-6210c767c3b8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 429", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8583), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, new Guid("df306578-0862-48f3-8b75-28608a4b314b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 430", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8594), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, new Guid("7e382afd-3ec2-47ed-9116-5ff43956d139"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 431", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, new Guid("425f10fc-e4a0-4aab-8af6-f30f03f8622f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 432", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8650), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, new Guid("ec593c7e-ff5f-42b1-8685-5b965d89873c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 433", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, new Guid("9c6af675-25f1-438a-b424-a1baf3f839e2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 434", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8673), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, new Guid("7eafeda9-d872-4082-9a9b-8f74fabde6f9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 435", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8684), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, new Guid("3190d673-c631-405e-b428-17a2199ccb8d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 436", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, new Guid("1ed88198-f7ad-4d05-ac71-23d9f5692797"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 437", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, new Guid("d7e867ab-c849-4372-8ce9-c4f186ecd6ba"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 438", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, new Guid("a285e951-7375-4fca-acd8-9fc350f23edc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 439", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, new Guid("4262d5c1-f90d-451e-8966-51bef395e2b6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 440", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, new Guid("bd5b6a2e-bd64-4b91-a097-ec1ef1712505"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 441", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8755), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, new Guid("5c52c70f-68f0-4e1d-b5b4-c5b78fb8e7c9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 442", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, new Guid("15b7b7f4-edf9-475c-90fe-150128e49e82"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 443", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, new Guid("2e403e82-cc4d-488e-ab4a-9be50c4ca136"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 444", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, new Guid("ed612653-39c0-442d-b6c5-93c5988fc8a5"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 445", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8868), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, new Guid("4ea3cb39-f4d5-4c60-aff3-bb6d9fcc8fcb"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 446", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, new Guid("fa5b58dc-a907-48ef-951f-0e22415944d1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 447", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8903), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, new Guid("53891516-6662-474c-ac48-fd156b878a1c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 448", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, new Guid("77d736ff-78c6-4a2f-9b32-f744b831f6a9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 449", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, new Guid("da7fe672-3419-4a32-b45d-eec6964e7cd9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 450", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, new Guid("e4fad9a5-b704-470d-b43f-956c9e285d62"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 451", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8967), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, new Guid("5254dc53-ed5b-4e36-892d-09ff7c5f5de0"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 452", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8981), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, new Guid("850adeb6-4ab5-423d-8ac4-2a5776e277f4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 453", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(8992), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, new Guid("80390730-5c02-4e7a-b9c9-e9bf2a1ed9b3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 454", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, new Guid("a8c35a66-ac0d-4be2-9283-7574697158dd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 455", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9044), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, new Guid("300560e8-76be-49aa-b0fa-4bd57aab6ab7"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 456", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9059), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, new Guid("16f32640-2681-4e77-b40c-c87171231f1c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 457", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, new Guid("4ca1b7b4-f0a8-4f41-a5e8-3983d9315753"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 458", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, new Guid("f00931c2-4ce8-4040-a1b1-8d0078ae1d5e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 459", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9093), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, new Guid("984ad0ea-e76a-41c9-8460-95218ef5ebc9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 460", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9107), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, new Guid("637b2f9a-ba82-40eb-84cb-ec7c09f58d65"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 461", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, new Guid("d9078f64-3e1f-43fd-af2a-d969b437cb39"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 462", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9130), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, new Guid("1f894ad1-4283-4a5a-9f70-f56a97ffc96a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 463", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9141), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, new Guid("3acb7add-726f-457f-9c2f-71dd23fd0fe0"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 464", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9156), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, new Guid("9ce52db2-d079-4bcb-9c6e-19989d70ec2a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 465", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, new Guid("829a4898-9e7a-4ea1-909d-c61cfe0a84dd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 466", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, new Guid("8640399e-3176-4aed-a6c6-99f28d0a5a42"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 467", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, new Guid("357a39e8-adb8-4428-ae79-12987d9d11be"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 468", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9233), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, new Guid("2800a360-11c3-4304-be8a-e5145c070c2b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 469", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, new Guid("4661f15c-5bbf-4832-a967-6efde5f6bc35"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 470", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, new Guid("b4d3f30f-bc16-4cb9-9c70-a39cef2bc143"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 471", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9266), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, new Guid("53b2d593-88c9-4d15-9d2a-a66392aa2a81"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 472", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9280), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, new Guid("62df3a65-7dad-4447-9de0-086b8ac61666"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 473", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9292), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, new Guid("82619de7-c8e7-4251-828e-38e12dcc1a9c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 474", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, new Guid("80e3a4e4-b596-475c-a885-5f851d464f3b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 475", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9314), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, new Guid("7a86e546-2f5b-40b5-9c7c-e4224581b73c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 476", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, new Guid("d67ef18c-576b-4707-ac3d-72b9033795be"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 477", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, new Guid("311a4abb-f5fb-4298-bfb8-91121160e985"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 478", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, new Guid("7333ff2e-8c08-475e-884b-bf9294502059"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 479", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, new Guid("ab1f5690-6fd6-42fc-bd29-16eeb297a8bc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 480", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, new Guid("6ec4d8b7-f931-4e44-861c-0d087a15b323"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 481", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, new Guid("d6b146e7-8c68-431a-855a-d3886850e06e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 482", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9461), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, new Guid("c463cc91-ad48-4fa7-b0ba-90d06f61f5a6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 483", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, new Guid("e9233ef5-7683-468f-aafc-0ee1f2404bf5"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 484", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, new Guid("9f676c17-e49d-4985-86cc-7ae2000039c2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 485", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, new Guid("55589167-7645-4efc-9b04-b97ddffb63c1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 486", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, new Guid("84b5fed1-43dc-4ec4-bd6e-956d755a2fd9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 487", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, new Guid("c209470c-3687-4005-856f-b70162318b65"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 488", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9567), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, new Guid("bcfb091e-bfa5-4460-8269-c531d692cc13"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 489", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9578), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, new Guid("f95bdd41-d86d-4552-915f-303ab6450a91"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 490", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, new Guid("86152e8a-2520-465b-ab8c-15eb06a4abe8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 491", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, new Guid("62ef6301-5585-413a-b0f2-9b013022c94a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 492", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9666), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, new Guid("5bd6f637-c1b4-41dc-8c2c-73bc787ace1e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 493", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9686), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, new Guid("59618c0f-e5fe-4093-a466-9cf7babfeb10"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 494", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9704), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, new Guid("e78ce10e-9c28-4f6c-b93c-0de33b993f10"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 495", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, new Guid("1c9993b1-5994-40b7-b428-cb2062c510b3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 496", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9734), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, new Guid("ce4b66ec-6ce5-456f-89c5-aba9af02dff1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 497", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, new Guid("d0d748dc-3072-424d-8f8b-bf0f77fcfba3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 498", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, new Guid("b6edcc18-6c56-4f5c-96bd-14e5dde0035d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 499", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9786), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("30c9f0f7-b663-4192-bb9e-d6287a4b4ecf"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5461), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("2157ee4c-48ed-461d-9e92-c87fa2f82343"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("c568efff-bc6c-4ebc-b773-54e44c53dd53"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5505), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(19), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(20), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(33), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(44), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(57), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(58), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(71), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(72), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(85), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(86), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(102), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(122), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(142), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(157), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(256), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(265), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(286), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(295), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(304), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(313), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(331), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(340), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(349), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(358), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(367), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(376), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(385), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(394), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(403), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(412), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(449), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(458), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(467), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(475), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(484), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(510), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(519), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(528), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(537), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(565), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(579), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(593), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(608), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(625), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(640), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(655), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(700), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(713), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(722), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(731), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(740), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(766), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(774), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(783), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(792), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(801), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(810), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(836), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(845), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(854), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(863), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(872), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(880), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(925), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(935), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(943), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(952), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(961), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(979), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(988), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1005), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1014), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1023), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1031), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1040), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1049), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1058), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1066), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1075), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1084), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1093), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1102), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1111), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1146), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1156), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1164), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1173), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1181), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1199), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1208), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1216), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1225), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1233), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1242), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1250), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1268), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1276), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1285), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1322), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1349), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1358), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1366), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1375), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1392), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1400), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1409), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1418), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1427), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1436), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1445), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1463), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1480), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1489), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1507), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1569), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1577), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1595), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1604), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1613), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1631), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1657), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1666), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1675), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1710), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1719), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1728), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1737), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1768), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1778), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1787), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1795), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1804), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1813), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1822), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1830), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1839), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1848), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1856), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1865), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1874), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1882), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1891), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1900), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1908), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1917), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1925), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1934), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1943), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1951), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(1960), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2011), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2020), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2028), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2037), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2046), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2055), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2063), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2072), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2081), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2090), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2098), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2107), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2116), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2125), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2159), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2168), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2176), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2185), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2194), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2239), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2256), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2311), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2320), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2329), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2346), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2381), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2390), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2398), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2407), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2453), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2463), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2472), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2481), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2489), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2507), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2515), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2524), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2533), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2542), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2551), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2560), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2569), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2578), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2595), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2630), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2640), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2657), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2666), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2683), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2692), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2701), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2710), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2727), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2736), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2746), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2754), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2763), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2805), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2814), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2823), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2836), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2852), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2866), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2880), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2895), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2910), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2924), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2941), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2955), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2970), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2984), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(2999), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3014), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3027), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3035), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3044), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3053), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3062), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3100), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3110), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3119), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3128), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3145), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3153), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3187), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3221), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3229), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3238), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3254), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3271), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3280), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3328), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3371), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3389), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3398), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3415), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3432), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3441), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3450), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3459), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3468), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3481), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3496), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3510), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3525), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3540), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3592), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3623), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3638), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3653), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3667), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3711), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3720), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3729), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3747), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3755), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3764), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3772), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3789), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3798), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3806), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3859), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3868), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3877), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3886), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3895), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3903), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3912), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3921), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3930), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3938), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3947), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3973), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3982), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3991), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(3999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4000), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4008), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4017), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4025), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4034), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4043), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4083), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4128), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4143), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4173), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4188), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4203), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4217), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4231), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4246), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4261), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4293), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4302), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4311), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4319), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4328), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4337), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4346), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4384), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4394), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4403), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4412), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4421), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4429), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4438), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4447), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4456), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4464), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4473), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4482), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4499), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4507), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4533), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5391), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5393), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5515), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5519), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5521), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4812), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4842), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4870), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4570), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4638), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("2f66cdfa-1d9f-48ea-a903-0b30237f8046"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("dcb2521d-a2af-41c8-aad3-787fca3f3e5f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("021cba98-1ddf-4c78-af19-5deae387be9a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("6bf5a2d9-4ad9-4b7c-ab65-338b99dc92a8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("14a57fb4-8e0e-4219-a216-d09d03ce37c8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("3190c1b6-48f7-4ab1-95e9-6b4a3b834840"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("ca32e204-68b1-4551-bb80-1e92d69733b8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("7df1ee6c-f606-4b5a-be90-4aee39a86d28"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("327918de-1584-4081-9f61-d20410e370e0"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(6343), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("cee08a00-0815-4d61-bba2-82bae0b60ac1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("55eb7fce-a5fc-4326-8cb3-12561877d01b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5723), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("30c18338-b572-473d-8c3a-f142b8d301aa"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("d662e7fe-03a7-4036-87ba-db28c1a58428"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("bb28f4c2-6907-473a-a556-97958f3afd0f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5765), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("3c98eb93-0ec0-46be-aa60-d9264f4aedee"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("1b5b4d04-2529-4840-9e66-116b9f783eba"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("59d2ef03-4acb-4beb-8706-1c3264f5ad30"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("a13e9817-cf74-46b9-9a3a-db1233190639"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5782), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("bc273e9b-c777-41d1-bb87-40081ccad19c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5785), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("13724aea-ab53-40a3-942e-dd683f0012b4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("1cc1c3b1-ea73-4ae4-8136-f70fbfd3cd69"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5792), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("f49adfe4-cd5b-41df-83ed-9f46e2d214a8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5795), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("d333ab2e-5f79-4eaa-b429-5f98741872b4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5800), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("27f2dad7-1aff-4d0f-9892-d8f1a1b94333"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("6a66e310-57ac-48c0-8862-7c7cbf608a92"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("daf68c24-6a00-48be-90d3-f2325d998a2b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5812), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("52ff1b06-1b40-470a-bb32-26ac020d5d5a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5815), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("0ab446fb-c5a0-4266-a457-5525784336a1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("0e42a2b9-b241-4c51-98bb-2fb6de37c390"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5822), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("eb495882-573d-4e61-aff8-40b01e3a2465"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5826), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("d627c0ae-4817-45b4-8bb6-517d56cbcbe7"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5829), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("6e35c92c-18d4-4cbb-be8c-057afb0d8585"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("4cd89ff9-2d09-4493-b34e-0ca791d74f0e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5837), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("0ac0a28f-d6a9-4a23-a8b4-452e1a06c3bb"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5841), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("2d1700ec-8172-44c0-919f-5d718a8ab9ec"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("c6c9cf75-a617-438d-9f14-e1a73ab678dd"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5848), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("7a9905a0-1e78-402e-85b9-466462da32ae"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5851), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("bb81bab7-3b1a-40ab-8d83-81c99a2c7b1d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("34a6e7db-544a-4544-a224-1c994a897723"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("dfac029d-9787-4d04-b23a-a3aa3574c2d2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5863), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("4d405ad4-5bc9-412f-ae77-a87679e07b73"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("64e248b5-07a6-4d56-9bdf-1cd5534f7188"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5871), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("7b8563ae-904d-4a07-9e69-c7c91d7199e6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("256774fc-5f85-404f-9d3f-0129777590e9"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5918), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("82e53ac7-3b31-4056-bcaf-677e27f84a1a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5921), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("a576fd23-1cf0-4582-905e-56a225ebd79c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5925), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("ab5e6096-8e85-4980-b882-026722793165"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5928), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("2bd6d20a-c9ef-4237-ab60-60e0967163c1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5932), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("82e24c43-6992-4f10-a882-b12427d9a39a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5937), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("a63e5357-43b1-4f37-a3c8-f4b85658e9ba"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5940), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("523d97cd-cc6a-472c-b07f-411e762ee9ee"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5944), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("927a9c5f-c6cc-45cb-98b7-62ffd1a22ff4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5947), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("bfda6bd2-5320-4e3a-8114-f2fb65ae9751"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("ad476c81-82d4-42ae-9979-9d27d4fb0214"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("c806f324-33f3-4ac7-b61b-79405142d543"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("b502c7bf-e38f-4961-b751-dd2af408d64e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5965), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("bc77ede5-b331-4930-8148-f8740471d5d2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5972), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("74454f17-56a0-4b15-830a-2e1b3ba29c5c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5977), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("b62f5f9f-8795-40ae-a63e-7b46dd7d38bc"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5982), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("feccf9df-6e1a-4de7-82b0-2927ead7fca1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5987), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("3e22477d-3d2a-481e-86c5-3543f75e14d6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("9fa0ca56-bc05-47ef-88d8-e168f61424e8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5997), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("9925e4b9-abef-47e0-afb3-9226fc81491d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("5a73d31c-4c90-483b-8e35-70d9d112cc9b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6007), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("370736a3-8bee-469f-8245-0cf1f80c3e97"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("e5047d40-b3db-410f-9835-7efbe150e14c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("05da8677-5939-4e43-b31a-637f8542df6a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("674d63f4-06ee-4d90-be11-01e7f92602e4"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6031), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("2ca12981-fff3-4be0-ab05-8ac2e733198c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("02abc8df-428d-48af-b9be-0b31e4937e14"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6042), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("c07c7599-8ad1-4051-8854-7dd7165ce8ae"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("82d09cd6-6ecc-4e87-a2d4-8ea1f2b7ed9c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("10ad34bd-f7a5-4ed4-a841-2dafd3935f14"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6093), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("2159998e-c39a-4176-afa2-10db8efb04ad"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("b4a0813f-5ef5-4a05-94fa-ecc819a376f8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6106), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("48a612b5-5d6d-49ca-a7ea-a39e46a4719c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6111), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("99685538-4bcb-494e-a4dd-2990675f5bb2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6116), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("3e484d3b-6958-477b-acc5-73d6d8c2d82b"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6122), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("ed111c52-9736-4526-9d71-b3abc16932f6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6127), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("e7aa57aa-bb06-405f-9bf7-9df8fd4ac4c8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6132), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("70662b9e-7f9d-4281-8689-77eeab3a4622"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("0d01b4ff-3b13-4a00-a688-b27cd1d00aa5"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6145), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("3547f1ba-5822-410b-874e-167be76c8ce6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6152), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("fe32beb1-0222-4202-953b-2196c9046b9d"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6156), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("e1dcb1e7-a4ec-46c4-a533-5347f121dcab"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6159), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("85d0adec-d224-49ad-b424-63d7c9a1883f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6162), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("d7441e31-cb5e-4f25-9fb0-d3a1ece37f5e"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6166), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("6a30bbce-f848-49af-b30d-5d237ff56669"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6169), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("d2d7c331-a2dc-4c14-b25e-c6e0b8e868f3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6174), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("8b9d7829-03ac-4e2b-9346-a0303afc4064"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("2a614d2d-a7bc-4347-a1a8-6444a6963fc8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6181), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("01d4f713-9028-4306-b1a1-0f6ac1fd4074"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6185), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("b364fa2b-d987-4af3-ad63-c8722f466a45"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6188), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("c7c0413d-031e-434a-8b50-5a6ee9b60337"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6191), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("1c8c7641-e489-4d16-aa65-661e15da11a6"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("cf8ecb14-773b-4b2e-89b4-961785a8eb84"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6198), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("572d2dc6-3976-4d5c-a65e-1a6ce797cc48"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6203), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("70b89022-eaf3-4ea8-98e2-7a2d82d4bd21"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6207), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("73166840-7894-4f30-b7a3-297324c5c4c2"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6210), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("acc8ab6b-3251-46a1-ac09-d1f42fceb86c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6213), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("7c417646-c06a-4a80-a36f-b48a47899f6a"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6217), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("7d0d25d1-c470-4493-b838-e8197216e827"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("19c3de01-5095-4378-b7d4-f6131aa3e6ab"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6224), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("60456451-0272-484a-9c45-98b806a725c3"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6227), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("6fbfd2ed-8da8-4f00-baa5-5d548a1e6feb"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6232), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("4799de42-4021-448c-b8c7-c5c448920739"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6236), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("e851c6d5-5fa9-44dd-b167-a39c24872a54"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6267), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("01076f41-b5c2-4e8a-b3fc-93c7a60102d8"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6271), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("948c1590-7b04-40f3-8906-1299d9548d7c"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6275), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9819), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9846), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9854), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9862), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9901), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9912), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9928), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9937), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9944), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9952), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9960), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9969), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9977), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9985), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 410, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5590), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5597), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5662), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4658), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4774), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4904), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4934), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4957), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4972), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(4985), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("c65b9ce8-0992-4a21-b29d-01ef5f3d382f"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5698), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("e796af17-2e3f-4686-a6d1-816807708952"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5702), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("35e8b135-e2d9-435a-bfaf-32cd326a4031"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5705), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("d079e7d3-8273-42d7-b9d1-990a94b29bc1"), new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6368), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6371), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6374), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6375), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 27, 9, 26, 10, 411, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
                name: "IX_booking_detail_drivers_driver_id_booking_detail_id",
                table: "booking_detail_drivers",
                columns: new[] { "driver_id", "booking_detail_id" },
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
                name: "promotion_users");

            migrationBuilder.DropTable(
                name: "route_routines");

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
