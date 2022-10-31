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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("b4a9c331-5e8d-4895-87c1-ee085246882f")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 95, DateTimeKind.Unspecified).AddTicks(1929), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("8f5886e4-2f5a-454c-bf20-056af9b843e1")),
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
                    { 1, new Guid("4b75783c-e96a-4d65-9dd9-551cda50534a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3730), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("cd434092-bad4-4d5d-8bd6-4b95992e9a8f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("6ee9cbab-4199-4fc4-964e-a0c0d82051c4"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3741), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("75c4b204-b7ac-41a9-bf02-23f3e7303ab6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("6f517edd-e639-42a4-bd6e-314cbd49da59"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("13937519-e226-4269-95a4-2a10c916b2ec"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("4e71f5ae-ff7b-4f71-8f94-573ec75a4777"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("b9018383-abab-4efb-9e6f-eb23fdbd0477"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("b6449891-4694-48b1-9970-6bce34b61eb2"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("f40c7518-6063-430b-8e73-13087bcd87d8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("bf9f5028-6970-4b0f-a865-3f13329216b7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("c4bdee32-16b9-4ecf-aaa4-e597032c2f92"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("23bf447b-74ba-4560-bc3d-7dc15e357bc8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("e9c0d8d2-8b97-49a0-8a19-470c8b03f571"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("21e819d3-61c4-4490-9a48-fa94a5ef2d23"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("191376b6-a4f0-4b38-a762-6ae31fdc7eb5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2563), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1752), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1771), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("56880ed3-f227-48a8-a6d5-e16c0c75139d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("edac3cc6-585e-424b-ba46-db999a7efd17"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5d1afc84-80fd-4587-b270-6fab76c155a7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2203), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fdd70971-7ab9-4f71-9798-68ac4aab7843"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("232ff1dd-807f-4d2d-a1bc-43a9c5d7f561"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("122aeffe-9dd6-4221-9af5-ff9660c13c67"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("399d4d61-cf0e-4972-89f7-7fda9058d1b3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2221), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2138237b-ea51-44f1-a047-cb59ff610bef"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("0cdfa453-2cf6-4f8a-929b-83dec4d9b4cb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("160885da-a1f4-42e2-8e53-68b7af803954"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8e779997-c212-4fa6-96fb-efeb0644231e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d96eb14-c674-4e0d-833f-b8103088752c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2baed099-6877-404d-b7b4-2d98c35cfb66"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("bfe5daf4-2b1b-4909-a824-968a1699942b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2246), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("242d685a-23a5-4aef-a4cb-90fa8d42878b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6148ffe5-d7d9-448b-82c3-3be0408b6120"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2251), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("19807bdd-5179-466d-adb9-7b8e466c16a1"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6ea3aa4-f9f4-4768-abba-a310eaae7a08"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e3137f0e-164a-4248-9a24-b3ca57e51e0f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6ef12194-350c-4b7c-80ae-1204951af7fc"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2264), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4d25c4be-ca1c-4f8d-bc3d-47ce75cf3417"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ccc17091-e1f7-4851-a9dd-511fec284a14"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("17ce6920-0631-459f-afbe-5083c54f3ec3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2278), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dd22f154-a14b-40da-8ba8-33d675407773"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("59b3c079-ed46-413a-813d-243737447150"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b57c5a78-02ea-411b-8c58-6b5fa15bd4e8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2287), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cbd2e443-e28e-42b4-a8ec-a6c340d53146"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8930001b-ede4-4333-aa26-c346d6628411"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8c247619-d781-49cf-a884-0104f4169579"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("46ec70f6-9958-4095-9757-235a4f0614be"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("172d44c3-cab3-40c1-8004-9dc9bccf93ef"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2146e566-e79a-403c-a85f-c9bc413809ff"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("404f9e84-75f9-4b64-aa80-48d4e4db2b7c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1ed8a874-2515-4fa1-9338-911f296af570"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4b50a9af-8142-4def-91db-e3bd7d7c9f0e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1c356fb-b418-4592-a6a5-a1ca6edcadd6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("f9bf66ee-de6a-4360-b765-217df7b269e7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6597457f-2043-4edd-8177-d384f8f251bd"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("745596b5-4c8b-4328-b712-6f847b137602"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2375), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2866e4f7-38c1-4a22-b618-69d919dbfbc3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5f89236c-2bae-4281-9efc-365ddb58d7dc"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e5cc8274-39b5-405d-be41-6b0394e84102"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("0c1a011b-3e36-48d0-b906-2b78fed7b7ec"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("f81a26c4-9649-4978-9355-3fe27ee17df6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c396968-711d-483e-8310-9661f511d498"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2395), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b3b42031-85a2-4be7-a69b-73c15723bdc7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fd9f55cc-d32e-4fa2-91db-88ade7b9703e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bd5aaf47-6f40-42cb-9ae8-b27da8cb44b6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ebcf87e6-1da4-42fd-b207-d961c53f5229"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c2e37a00-fc11-4ee9-8f3f-b9fc95cd3823"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4dd2f47b-c0fb-48f9-aafc-599d4e51e3ce"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2411), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2a339c0d-689d-409c-861e-6cdef4e1e593"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2414), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9f954697-f6c9-4255-a8d0-82a27e566782"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("905b6818-5b6f-49a2-bd89-7c676bb325b3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bd0c453e-2da3-4095-a835-08e9c2bc6be5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0461acb-868f-463f-a7ff-af59194308b5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("74ef6ccd-4340-453e-ad6f-13d74f970838"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("16af6683-aef4-4b1c-a776-7ab551a89ff4"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2435), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8b6d3f2b-74d0-49d0-8d85-93e2e244a231"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b505191-91ed-4e02-919f-73658b886a51"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2b3f8fa7-f851-45cc-9d82-f5eef23a4c2f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8543bdc4-abaa-4875-9b0b-d8643e6d8013"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("24d0b8ad-ad1a-4271-9733-e07394678d0e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("636f7734-8a0f-4c8e-ae0c-a84783947a35"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7ee19ab6-0d30-4e28-ae79-6859f30dd1f7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("32e107fb-4953-48b7-adc4-ad5e4e1e870d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("942832ae-eba6-49c6-910d-950b3d1f88f5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fc545dbc-4a0f-4f87-96ec-3816ee654507"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2468), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a634835f-628b-4793-baa6-92699781bf94"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0effac11-8e44-4120-8f47-402b08ffeac6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("7a728cc0-25eb-4327-9e23-0af151d81c26"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2480), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("37e2bd64-7b35-4881-940d-b6b0d868cfb3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7ac42540-c6b4-458f-ae4b-dff789fb4f47"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2524), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("66f34a92-11f7-439c-b47a-3e24feaf5124"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2526), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6fcb0b62-5047-4c90-b5a6-05ea3d947231"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0cb7eb83-da20-4418-a608-dbf9036f89c6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1c8df9a4-6676-4de6-8c90-34ca279de11f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2541), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c51c9d47-c341-46de-aed9-bec9ea66c5bb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("85727bfa-3364-473c-b597-15cb8757bab4"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("d8975932-df0a-43a1-a252-7337413bd15f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("be8c7b5b-7089-4dd4-8e29-2a9d03719bad"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("1f497057-8c5c-4412-8570-57a396291f15"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("dbc02a6b-c4fb-4bb5-a85e-ab6f56a00b30"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("899f67f9-24fc-4b52-a7f8-1aab4049d317"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cd720f1d-7f55-4082-bd22-44c69a74766b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2276), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("667651ea-f9a2-45eb-9118-1b9adb98278c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2642), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("028e1d5f-5e4b-4465-82e0-f869cf6248f6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("040f19bb-df2f-4910-80b1-73c9ee9a0b91"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("862af894-0530-44ac-a5bb-8238bee403d0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, new Guid("d8bd521c-045c-43b9-bf08-691f049ea444"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 100", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, new Guid("b32186c9-8c44-46c8-b990-77d519ea0d85"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 101", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2862), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, new Guid("8f1ac72f-f975-4d58-b3ff-fe8b22dd2741"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 102", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, new Guid("035b5fc9-71d0-4ef2-be86-dd5b6e8fed49"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 103", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2893), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, new Guid("3bf00271-3764-4986-89c9-27bffa84099b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 104", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, new Guid("44ef57ed-043f-47ca-832a-a1ce30e962c0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 105", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, new Guid("97657b9c-d86b-46d8-825c-3d72060a4e2f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 106", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2935), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, new Guid("0c80a70a-11ef-4ac6-a203-be1e16337a1e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 107", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, new Guid("92ea6de3-ff67-4c2f-a516-c4c014a15bff"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 108", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, new Guid("d01f57e4-612a-4453-bb41-bea311813d80"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 109", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, new Guid("a7ebc397-9012-47f9-a87d-4655c49a062d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 110", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, new Guid("ccd2aaec-f5a1-474d-9e47-6f8b037bffa6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 111", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, new Guid("1fe0a3ec-3e84-41fd-aecc-a8633370ec21"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 112", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, new Guid("aabbbadd-066e-47b8-b1bd-960f69172edd"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 113", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, new Guid("f5352cbf-fb85-4c8c-8e71-1ebbcd46696b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 114", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, new Guid("34196ab7-b0a3-42e0-954f-7b4f7dc54e18"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 115", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, new Guid("e17b09f4-f993-46bb-97e1-0c34e00fc8ea"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 116", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, new Guid("0d0678ae-5faf-4f85-b6f9-6a84dfd2b045"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 117", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, new Guid("275eb389-85ee-4c1d-b910-b8651a7f0028"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 118", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, new Guid("1d980363-c55b-48a4-9023-3f73731bd4df"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 119", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3166), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, new Guid("2f8b67a2-b409-416e-8135-b18ed48529b5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 120", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, new Guid("157217aa-a6a9-4ec9-859b-f10f6935bc51"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 121", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3195), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, new Guid("2703cd11-422b-4661-9e6a-745ac38dbc82"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 122", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, new Guid("da3a07ff-b766-4a0d-9edc-2a3f4f9f595e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 123", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, new Guid("30e0ac78-3e15-45eb-9f90-3091c3ea8058"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 124", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, new Guid("504948eb-1c58-42ca-b067-7d14411d920b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 125", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, new Guid("e889dc81-e72f-4059-bc06-b4ce398f70d7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 126", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, new Guid("4936775e-c131-443e-b994-603e7a1585c8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 127", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3331), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, new Guid("abc31216-5a20-404b-b369-f41d7022f791"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 128", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3344), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, new Guid("7d2f36c3-2771-4640-b6c0-bfe2d91edafc"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 129", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, new Guid("58f1af8b-0016-424e-931c-fef841ff7e87"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 130", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3370), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, new Guid("84c93d13-70da-4e6f-bb9b-bd7e77754478"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 131", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, new Guid("47e94865-7163-406b-911e-9f877b0f1a2e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 132", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3398), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, new Guid("c7fd8786-6951-47ac-9fc5-d336c8da4ffe"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 133", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, new Guid("48ec2e2b-9967-486b-b452-2694d5f5e1dd"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 134", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, new Guid("034c0ce7-45e0-40b5-a389-110ccc386cf8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 135", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3441), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, new Guid("344a8cf8-f275-4980-b21e-1804e7578e3a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 136", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, new Guid("1d0d3a2f-b3d2-4068-a75d-64ca8593f870"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 137", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, new Guid("1d1bcfba-cedd-46e6-9e1a-e284d49fc0ca"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 138", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, new Guid("b9fc8832-fcc0-4293-80e4-1767a81c7edf"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 139", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3548), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, new Guid("bf8365e9-ebce-4754-a0d7-954809b11cdf"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 140", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3561), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, new Guid("f584ac96-2baf-417f-ada9-e6f65cd17252"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 141", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3574), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, new Guid("43ad4297-51f1-4dcc-bb5d-fa5c8e41b485"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 142", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, new Guid("8b890760-3c07-4a36-aed7-e7a7ee2b31cb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 143", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3603), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, new Guid("1c60fc4a-792b-49f6-8aa1-eeb5f6ef0e71"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 144", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, new Guid("d1f042f5-9458-4710-bd02-faa3145b48fc"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 145", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, new Guid("8331c0c7-cea6-483e-a31b-a14ba3675835"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 146", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3642), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, new Guid("f0e7a03a-a26a-4f30-8a71-e180c478a639"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 147", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3658), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, new Guid("e4473a53-4b2e-4bb4-bec4-519fe5ac5eb3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 148", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, new Guid("5d35ae3e-dfdf-49b0-85c1-896a9db5e366"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 149", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3729), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, new Guid("55766dd3-11c8-4353-ba08-77bdd5fd7c23"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 150", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3742), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, new Guid("ef4ad6a8-ed84-4d9d-b2c6-98aa8fbd0ac5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 151", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, new Guid("424e1c45-fb61-4606-b4b1-b8d879ef71fe"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 152", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, new Guid("23e5d9ac-042e-48f4-9f49-09f35541f051"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 153", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3787), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, new Guid("9b16dd65-dc2b-4055-b3a8-e7aacdd4273b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 154", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, new Guid("ac39bf7b-5c27-4c13-b3a3-007a3d9432e9"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 155", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, new Guid("dfe73ede-d149-4972-ab8d-4d609e301625"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 156", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, new Guid("a5151e19-b641-40c4-a224-819bd98cdfe1"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 157", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3843), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, new Guid("b76825ca-7b82-41c9-97f1-97a997790941"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 158", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3856), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, new Guid("15af2046-1f56-4bee-9a0f-a888dd617df7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 159", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3911), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, new Guid("5123c270-0e78-4cbd-b476-2317e51b69c8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 160", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, new Guid("80dd2b2e-0e25-473f-bc51-ff119f97a760"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 161", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, new Guid("43740b59-f2eb-4ca1-a07b-1397eed50b6e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 162", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, new Guid("1ba66430-5734-4afd-a806-8f1c1f55b631"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 163", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3969), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, new Guid("4f27768d-6e42-4796-96b6-b91e63bcd07e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 164", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3982), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, new Guid("64018916-ec39-411b-8b22-37c25e1d1cdf"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 165", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(3995), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, new Guid("fc512dd3-ce08-472c-9ac3-be114bede241"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 166", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4008), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, new Guid("c718d5d8-38dc-4104-b9ce-3f3ba303c78a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 167", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4024), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, new Guid("01083132-cdb2-4d5f-b67a-bd5c8c48f16d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 168", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4037), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, new Guid("0057039c-65bf-4e87-9510-b0eab9e1717e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 169", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, new Guid("031e00ad-2c89-4a47-8f45-c9ffffef221e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 170", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4063), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, new Guid("acf87b5d-e53b-4892-aa50-a24279d572ed"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 171", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4078), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, new Guid("4d000b0b-d260-449f-8670-6f1ee6e36087"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 172", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4155), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, new Guid("840388b5-c096-47ec-a659-d95ad9101fda"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 173", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4172), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, new Guid("2b721dcf-3e65-4c4c-ab0a-e2c2c1575356"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 174", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, new Guid("9d694eab-73f6-48f8-8f14-2b874ce8c312"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 175", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, new Guid("dcd6daf3-ccf9-4b0d-81ee-197828d7538b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 176", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, new Guid("dc30b4a8-91ce-408b-82fc-66e80ca39baa"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 177", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, new Guid("607d8630-2f50-46f2-a48d-a07527737a15"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 178", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4241), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, new Guid("eecb9efe-edd6-4802-8acc-c1fc0c71ebf3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 179", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, new Guid("bef857a7-2724-49a8-ab78-2b04b95c6142"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 180", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, new Guid("2987b88b-bde4-4921-b958-3d48b55d12bc"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 181", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, new Guid("99dcba19-2252-4f39-b2bf-8350665c8e06"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 182", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, new Guid("868a5667-9abc-4f87-b714-b329ccbb122c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 183", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, new Guid("760375ac-b20d-48f5-b798-0b7c5d519db6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 184", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, new Guid("2e209f0a-43c6-43af-9f81-b708934f6625"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 185", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, new Guid("9a45c64a-3645-4084-9bf1-c104d6780e86"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 186", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, new Guid("dc390caa-35e8-447f-a1ed-0c937f0d50d8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 187", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4409), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, new Guid("c1ff51fc-530d-408b-870f-76e2719e486f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 188", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4506), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, new Guid("52ac7b61-3a93-4e0d-a0bf-c28f952e0520"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 189", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4525), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, new Guid("df39e130-5eb7-4007-86e9-045638075a57"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 190", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4538), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, new Guid("f2339710-3ff2-4d25-a98d-11f8f19043cc"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 191", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, new Guid("35568c1b-fd02-4243-91bf-fc29a840f5e6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 192", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, new Guid("66031123-cd6d-44b0-b251-0342b526a495"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 193", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4581), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, new Guid("96cbf5ed-4a91-47da-948c-8ca7f744c1c9"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 194", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4595), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, new Guid("55d43fd2-679d-4132-b861-8cdac579768d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 195", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, new Guid("33388423-66e6-46b6-b5e5-69f0bfe0b9be"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 196", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4625), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, new Guid("ab9a576e-bc18-4c6b-983d-b6b0017d365f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 197", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4638), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, new Guid("33b68a72-7586-4ca9-9574-3148c67015a8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 198", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, new Guid("05cdd297-c0da-4042-a223-1fa508042d74"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 199", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, new Guid("1871e0f5-987f-4e1d-92e1-716b43db5573"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 400", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, new Guid("7491426f-c09a-46c6-a5f4-6886309f9247"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 401", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, new Guid("89282b34-145d-4bb5-bc0a-309cbe260ea2"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 402", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, new Guid("0d808545-eed2-4c9a-a4d2-8390996d491d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 403", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, new Guid("5963e3d2-c221-4cd6-b324-5f7d1bdec354"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 404", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, new Guid("b8c0d263-4e38-48cc-b706-1f22e0861681"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 405", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4843), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, new Guid("2fdddadb-87f6-407b-93c7-72919df43907"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 406", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4856), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, new Guid("c3f214da-04b4-4290-a5f7-423cb72c370d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 407", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, new Guid("a6bbe41a-7435-4a26-b216-e0bc05d41afe"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 408", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4886), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, new Guid("9c435a28-28ee-43cc-8601-c5cec6175855"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 409", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4899), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, new Guid("8b29b20d-eb71-45ef-aaf9-e871e3cd9866"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 410", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, new Guid("f1bd022d-6b7c-4b4e-8ab8-3412fb958f3f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 411", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4972), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, new Guid("cad29b48-a0be-49a0-8a09-341f0af90409"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 412", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, new Guid("c769a509-4179-4e4c-bca9-62ce0a56337a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 413", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(4999), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, new Guid("8dd55b47-3be1-449c-997d-26172ccbf9c4"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 414", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5013), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, new Guid("0ae61322-818d-48f3-80d2-1be2a2972fba"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 415", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5029), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, new Guid("8a333f21-ffb7-4fff-8602-e2ddef93635e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 416", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, new Guid("f4e76a85-87e5-4575-9661-d7b9325a12a1"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 417", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5058), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, new Guid("38bcb705-75c5-4d4c-badb-29e2bf56e06e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 418", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, new Guid("970c71d9-1a14-41a3-aa74-251572f678ee"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 419", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, new Guid("d7d1d7ce-f27b-40be-af5a-808de31e4e80"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 420", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, new Guid("aec7d54b-f4fa-47f2-ad93-6bad1b79f2e3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 421", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, new Guid("1075c893-60be-4758-a844-6c7dbfec6fb8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 422", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, new Guid("7e100a86-6b5f-412e-a67e-76c2a41aa2f5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 423", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, new Guid("48a856c6-60c7-496a-a49a-71ed5173e6cd"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 424", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5216), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, new Guid("417da86e-c132-4a95-b104-1abd01bc743b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 425", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, new Guid("7f254f5b-4700-4ab5-b6ef-2ac466e12eb3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 426", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5242), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, new Guid("c5bec9b5-13c6-4a2f-bf27-d060edeed374"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 427", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, new Guid("fd320b77-d753-4a81-8d3b-7b0177a68923"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 428", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, new Guid("066c47cf-7328-4f00-ab7c-fa5b89174cfe"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 429", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5284), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, new Guid("5e2c71dc-d5e8-4066-ba29-852a46790f3e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 430", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, new Guid("da595da4-b988-4cdf-9c09-44204806d755"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 431", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, new Guid("0b8cd8e4-7834-464f-ae79-3552ca402075"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 432", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, new Guid("1d29af37-f80f-4420-bcf6-d724455d6e4f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 433", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, new Guid("89b5e29f-03c3-473f-be99-3c09a076f83c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 434", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, new Guid("fd7a79bc-f0af-4b05-8198-8109b053e08a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 435", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5414), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, new Guid("9be2d8e5-3b11-4d5a-bc84-e29bd6fc4599"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 436", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, new Guid("cd5c4147-e54f-459f-ba40-f6ae628c1f3e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 437", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, new Guid("071731f1-60fb-4cb1-985e-f16e06c190d7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 438", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, new Guid("6051bc2a-7bd5-4399-9340-dfa74c5e7a21"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 439", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, new Guid("b79bc844-cda2-455b-9c9d-791cceba480d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 440", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, new Guid("1f32b873-bf78-41f6-8d28-9cc7c9dca1f3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 441", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, new Guid("1f2ffe1d-7d39-4eb2-8a6f-be590026ba45"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 442", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, new Guid("54f57e0d-c768-4003-ac64-dda27d0053eb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 443", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5525), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, new Guid("8b7b6bde-475e-40c3-8fd4-e2b3badfb16d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 444", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5538), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, new Guid("83ddd329-73e4-409c-a17f-cfde7a92d0dc"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 445", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5551), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, new Guid("ad9b3a8a-a853-449a-a3c8-5bd51a9ebd7b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 446", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, new Guid("a5ff6d43-6b98-4232-80d1-8772363ba0a8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 447", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, new Guid("6bee1a25-d4ac-40ca-bec1-65404b160d1e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 448", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, new Guid("84801def-4ee8-4c79-bf8e-3df5426f9007"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 449", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, new Guid("9530af87-2b86-4629-a0e4-e7d541b547aa"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 450", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, new Guid("9b21ea15-8004-42f8-86d9-466318be1df0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 451", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, new Guid("e4324da6-1c85-41e3-afe6-2a9d9f6c836f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 452", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, new Guid("6bd7a924-369b-4bbd-913b-70038e6b2ac8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 453", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5702), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, new Guid("ace86a14-2aaa-4447-a93d-95516d995a33"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 454", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, new Guid("9d4096f7-4d30-4348-a728-0174b529bbb0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 455", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5731), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, new Guid("24c8598a-f48c-446d-aab7-98a0f75aa222"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 456", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, new Guid("5d6eff1f-7d64-48a3-91ae-d33e7c2da0ed"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 457", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5757), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, new Guid("fbab3cd1-bb8c-4a23-9b60-b9c828ee42cb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 458", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5809), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, new Guid("9beb16e2-bae7-447f-91ee-efa8cd04394b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 459", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, new Guid("2a52dd56-8b18-4f24-88ab-71c711b1adbf"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 460", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, new Guid("afebf349-db44-42d0-b251-29343e3f7ad2"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 461", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5853), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, new Guid("425c87a0-1e78-4156-8d52-0346d4b44c1a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 462", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, new Guid("2805fb56-737c-4cd8-aaf9-1dc5bade60b3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 463", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, new Guid("f6e98091-4c28-4ec3-8a54-bbd316076ea8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 464", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, new Guid("f0317c84-99e0-45c5-82c9-f3b955a9607e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 465", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, new Guid("5875036e-12a2-4b16-8512-2f23367f218d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 466", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, new Guid("dde6583b-fdde-4b4b-af26-578a94396387"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 467", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5937), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, new Guid("7224c852-1560-4549-87ee-715d0c177da1"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 468", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, new Guid("e825fc81-8631-4e42-ae0e-bdd215382a5f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 469", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, new Guid("afddf46c-1b3b-4bfd-ae55-83251e46d24c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 470", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(5976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, new Guid("52dec1ae-6eaa-44c5-8603-5e9b8e08d8c5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 471", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, new Guid("fc74fcbb-4914-4a75-b65f-6a7572a44935"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 472", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, new Guid("c9866e9d-10a3-44d3-a4c6-d2786f0cb599"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 473", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6061), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, new Guid("59614c99-fdf6-43ad-813a-e3be5587f72b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 474", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, new Guid("61640005-89a7-48ba-8e47-ddaf7daf7341"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 475", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, new Guid("46ce6b99-6d9d-45d0-8daf-406058da2700"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 476", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6103), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, new Guid("5205fecd-fe0c-4709-b9c8-0ddda73aeac5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 477", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, new Guid("8a6df978-4f6e-4733-9a3e-03260600b5db"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 478", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, new Guid("b380efc1-0ade-4f28-90df-2a25a2b60e0a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 479", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, new Guid("f1e73abf-a825-498f-bcc0-b260ed239ee6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 480", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, new Guid("a111ecfb-9de9-4ce7-bf48-8d93d0a0b57d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 481", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, new Guid("27cc7319-b097-4dc3-9414-d717c0151fbd"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 482", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6184), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, new Guid("d6b2f5db-0b23-4d14-8c78-c4e862b5ff01"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 483", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, new Guid("c5daee08-6151-4f44-a08e-8eac48af59b7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 484", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, new Guid("d606f36a-bcf5-4be4-b2da-f0f0ffce8e76"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 485", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, new Guid("f2fb6293-993a-4c48-b1d3-5dd6ca2c8b66"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 486", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6287), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, new Guid("216d66ba-e494-49ff-af73-6b2ea98ae03b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 487", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, new Guid("7eec1593-10fd-418e-8f64-e1182d583146"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 488", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6316), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, new Guid("40530906-49b2-4f9a-aab8-a7f873655007"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 489", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, new Guid("ceae7ab0-5a17-4017-9580-f465bca982ec"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 490", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, new Guid("e9671ff6-99fc-469f-9be5-62af9b22a1c3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 491", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, new Guid("d23ab64d-8fc5-43b2-a655-102874f44ed9"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 492", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, new Guid("d460c7a0-7dc0-44a1-a178-b2171607d370"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 493", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, new Guid("57f66499-dd67-4791-bd04-635a917275c0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 494", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, new Guid("c5581ee7-a232-496b-88b5-7dd819327fbb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 495", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, new Guid("f4a5a29b-383b-4b48-977a-43bf563a73c6"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 496", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, new Guid("dc7b48a6-2daa-41bc-9e31-da3559732884"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 497", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, new Guid("c2823a84-a5d1-42db-ae62-3df05dc8f062"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 498", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, new Guid("03d1f1ca-661c-40df-b057-dcd46c06782a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 499", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6507), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("d6ea3563-cc48-4e05-a860-af67b73ef5b0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("c162f957-76eb-4c89-9fea-8751f57810ce"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("25e680f3-a4e3-4e80-885e-7079c6faf19a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6753), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6771), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6781), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6790), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6799), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6810), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6823), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6849), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6859), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6869), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6879), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6888), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6898), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6920), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6930), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6939), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6949), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7017), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7028), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7038), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7048), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7057), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7067), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7077), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7087), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7097), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7107), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7117), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7127), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7147), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7167), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7177), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7187), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7197), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7207), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7217), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7227), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7276), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7287), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7350), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7360), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7370), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7390), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7400), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7430), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7440), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7449), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7459), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7507), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7520), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7531), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7541), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7551), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7571), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7581), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7591), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7601), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7641), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7651), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7661), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7671), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7681), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7691), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7701), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7711), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7721), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7769), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7781), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7791), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7801), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7811), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7821), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7831), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7840), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7850), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7860), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7870), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7889), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7899), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7909), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7919), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7929), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7939), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7949), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7968), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7979), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(7989), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8039), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8050), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8060), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8070), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8080), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8092), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8112), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8122), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8133), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8142), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8153), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8163), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8173), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8183), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8193), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8241), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8254), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8265), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8275), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8285), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8294), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8304), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8315), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8325), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8335), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8345), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8355), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8375), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8385), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8394), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8414), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8424), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8434), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8444), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8454), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8581), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8606), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8616), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8625), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8645), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8655), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8665), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8674), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8684), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8694), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8703), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8723), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8733), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8742), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8752), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8762), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8772), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8781), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8791), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8842), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8862), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8872), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8881), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8901), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8929), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8939), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8958), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8968), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8977), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8987), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(8997), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9006), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9016), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9026), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9036), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9045), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9111), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9122), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9132), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9142), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9151), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9171), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9190), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9209), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9229), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9239), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9258), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9267), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9278), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9290), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9301), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9311), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9322), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9369), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9380), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9390), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9410), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9420), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9430), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9439), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9450), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9459), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9478), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9488), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9497), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9527), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9537), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9547), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9566), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9575), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9623), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9645), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9654), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9664), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9688), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9698), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9708), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9718), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9727), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9775), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9788), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9798), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9808), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9818), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9828), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9847), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9857), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9867), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9896), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9906), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9916), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9926), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9935), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9945), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9965), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9975), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(9985), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(33), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(44), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(54), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(55), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(64), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(74), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(75), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(84), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(85), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(94), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(94), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(104), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(114), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(124), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(134), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(178), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(190), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(219), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(229), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(259), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(278), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(338), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(358), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(368), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(397), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(417), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(428), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(467), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(477), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(486), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(496), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(506), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(526), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(535), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(545), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(594), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(615), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(634), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(644), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(654), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(663), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(673), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(683), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(693), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(703), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(712), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(722), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(732), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(741), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(799), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(848), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(859), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(869), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(879), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(908), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(928), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(938), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(948), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(957), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(967), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(977), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(986), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1006), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1016), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1025), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1035), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1054), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1118), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1130), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1141), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1180), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1200), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1210), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1220), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1230), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1240), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1250), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1260), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1269), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1279), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1289), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1299), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1308), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1318), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1328), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1381), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1393), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1403), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1422), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1432), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1452), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1481), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1491), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1501), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1511), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1521), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1531), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1541), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1551), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1561), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1581), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1660), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1670), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1690), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1699), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2686), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2692), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2696), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2805), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2812), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1956), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1977), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1727), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1742), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1783), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("2d97ba04-1b51-4b20-a1a6-651cf38f28f1"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("64afd3ba-6d19-48da-b11b-2b6d23faf19a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2602), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("35077330-1934-42f2-b9ce-3a1f1e6178c4"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2615), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("087eed9e-e9bd-4547-8b45-4d64e6fde165"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2631), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("8ed8f5cf-22b7-4818-89f5-0e9079e2512c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2643), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("e8aa1f10-72bd-4d5c-863f-c4d7928a1cf3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2658), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("05d6d167-042b-4d55-a1b5-e2f9b82b7f2b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("16094337-44ab-43b4-b782-27496dc8f7ac"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2690), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("cdb09966-d239-4e1f-9bb1-521273f9e86f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("a33e6546-856f-4d33-a23b-39d71d46b537"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3085), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("4c02dd4b-711e-44d8-8ab4-088e29eb54fa"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3097), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("072aa552-98c5-4c2e-8fa0-bd74ddf75dc0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("27016c26-0577-4f00-854f-f4afc058889b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("d945e34b-0432-4e09-a95e-276ded878e55"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3109), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("1faf2804-0ddd-43ad-8d72-11b7c1071a3a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("57a77edb-6085-4b63-8fd9-325b3eef88d5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3122), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("7e710dbf-1b8a-43a0-8361-c9af3504d102"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("b37dac8d-549d-4cc7-9d53-cc48cbb4d324"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("d753883f-7c3d-4bab-ab65-eafb8e2bdd92"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3133), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("2ce84bbb-4eba-448d-90d4-6c0f2f55a229"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("1f28fcd9-0097-4fda-9201-4e0cdde4f1b2"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("8067c759-85f9-4f39-bd61-6e8461252214"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("6f01de1a-c14e-441f-9b57-9a4640b320aa"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3152), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("490270b2-878c-458b-a1cb-2198616f2a31"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3156), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("5430426c-788d-4fb8-8e2e-4e9344ac9f72"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3160), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("704e64aa-3c17-45a0-bd4e-0f55b63bb74f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3164), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("d7c49796-d971-4b3a-9b92-eee404dd4126"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3167), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("67d8e55a-bf59-45fe-ac43-e56f1a0d836e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3171), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("f81aa231-1d30-4774-b31a-b42d1895981f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("458bbb76-c63e-459b-b962-704bb4bb1117"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("3daef2a8-db1d-4ec8-99eb-e7181b6a6e0b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3225), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("ecc5430a-e330-44a5-906b-74e3f0765a39"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3228), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("7bdca763-5097-4919-91f0-efc19cee66c0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3232), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("838504b8-f7bd-4f4b-916d-c44789736139"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3236), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("c60cd113-84f6-4fd8-b151-953271290532"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("c0c70c0a-afcb-41fa-8960-f6fb4934c4b9"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3244), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("fea8772f-2d89-4401-9ffd-5662e55f7146"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3247), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("c3345d6b-f4d8-4407-bbe8-0d445f9c3122"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3251), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("eb36e461-a1df-4499-b2d2-3df52345de14"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3259), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("8f16e801-80f9-4460-a3f6-97d39976093a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("b2194506-fcd2-4913-9a1d-4886cd1f0611"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("1b26bd24-9481-453d-847b-e1844dc2189b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("00281453-c6ee-4e11-9cfa-397bb47571e4"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3274), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("8d74984d-7bfc-4f6d-aa00-ca4b883ef201"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3278), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("86c0ba06-6756-45de-8fff-483cdfd63011"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("89eae54c-0b58-4b7c-86e1-60a9b05125e1"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3285), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("5a96cc85-11e7-4d79-b98b-697ddc987639"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3292), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("547b34b5-6127-42de-8f45-6bc1a3fe6c0c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("9ca99ef2-4a45-4110-bb01-dd59e8abf254"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3299), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("422fdcc4-a7ea-4d1c-9e5d-4b7cbd2eee6d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("ecbc6c04-bb12-49b4-90d3-8705aa4c21a7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("4e75e7b1-a6f2-4a8a-8abd-d2f4c2207c84"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3311), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("f1822b02-9460-4065-bfc4-fdc2110c8c95"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3315), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("b95cb0e3-75b7-4b57-895c-591ef74a35ea"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3318), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("1a2d238a-7c87-4caa-87d5-d3f61b6b9152"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3325), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("713f13a6-3365-4058-911f-e313c63487df"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3329), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("8f345169-02b0-4e79-9645-84ba5071b485"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3333), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("9e54bceb-bc53-4d1e-b068-527560f1569c"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("cdba2c46-f372-48fe-bee6-828427fd697e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3341), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("4de0e558-9d23-40d5-9679-f0245b60f21d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3344), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("5820388e-fde0-40b6-b9a7-db749e082169"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3409), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("544ab36a-8a22-423a-9b4d-3bf62f33393b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("0a419de4-41e2-4638-9fa8-c16ee8530ca4"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("5f8e12e3-d691-4f94-a1a0-77a0f210f984"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("06e0f52d-232b-479f-80cc-bb1cfaa8e321"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3428), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("e2a408d4-04d9-45fb-b8bf-8149163a6910"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3432), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("872292d1-ffc7-4a67-b88b-1d45051e361a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3435), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("9aa94485-9004-4976-9ed9-167556cf97a7"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3439), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("200887a7-b84d-42ca-b3ff-fd318f0295c9"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3443), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("7bb85316-a10d-4321-b947-e15d55b84317"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3447), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("13de7e5b-c993-452d-983e-315faf1641ab"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3454), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("05e81f1d-d087-490a-a5b6-94a986ce6493"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3458), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("9078deba-9df4-4bdd-983d-defc4b9ea593"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3462), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("ea6e4abc-5306-4d7a-9413-d77225430719"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3466), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("134c9a7f-3e39-4700-87f3-876ba810523b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3470), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("f3cd28f8-e772-4e15-9ae7-6643ab40a106"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3474), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("e5b2ba98-d19b-40ac-8545-61f5fa3844b5"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3477), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("2d983dd6-6324-4010-9ee1-4b860072b0d4"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3481), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("ea45b4b4-d881-435d-8275-b3513eb15459"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3488), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("dead0f03-94dd-4bd1-883e-3c579568d72b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("5a159b1e-5c02-4193-bf3b-a0226caaf844"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("315f8f44-7da8-4e2f-a914-5007e03c2e57"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3499), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("0d8e27ed-6db1-484c-9783-54c33b1e7977"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3503), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("1126d95f-0e3b-40a4-8911-0860d9faea59"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3507), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("c0451f54-508f-438b-82e9-d7ee0e34054a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3510), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("73c82b9a-0cca-4a63-8245-c55f8ba717f8"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3514), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("3c0f77ab-d3cd-4790-959d-aa720fc97cbb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("b1d64be1-fd6c-4453-ba76-1b46f9a013a0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3524), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("13956623-f8a7-496e-b1ef-1071b5dca063"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3528), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("633adc31-b7fe-4897-9ef9-4903790e689d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3532), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("33e1bac5-335b-4e7f-894a-c654a5ef7f95"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3577), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("a4a60789-a638-41e7-aad2-f6ace5dc338d"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3581), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("10e8fc09-5512-4334-b392-9f152fba8c7a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3584), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("02a39bac-4289-45dc-8d18-b4fb9fc66d06"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3588), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("6057993f-cdc7-49c4-8bca-388e3b7b375a"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("0c68a463-3610-4aad-a24d-db5e6da05dfb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3598), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("24cabf8b-dd51-492f-a9ad-ca989196054f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3602), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("89e9b358-814c-40cd-b926-0b8b609be06b"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3606), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("3c5bc22e-0336-4cbe-a7b9-112278133539"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3610), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("240d2699-a2a8-425a-a623-96689a4ac612"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3614), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("36eed0a5-20f7-480c-ad74-503a2ff88da9"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3618), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("9d5aba90-cc92-4af6-b479-f798bfeff513"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3621), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("7f74d001-10f4-42f9-bbb6-f3871d796c28"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3628), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("c597ef5e-9dbd-4b1e-8902-9605163c1f51"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("843dc827-865c-4dfc-ab03-3d1207b9ac7f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3636), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("9c190fed-545f-4f8e-9e0c-4285fe50030e"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3640), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("58c2e7e4-39c1-4897-a2aa-f9777ee3b169"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("aa4baf1a-6aac-42a0-b4dc-1f94ffc08ecb"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3647), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("bd93572f-8b5b-46e3-aa3c-13ea73ed947f"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3651), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6530), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6544), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6554), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6564), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6574), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6586), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6595), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6605), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6615), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6627), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6636), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6645), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6673), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6682), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6691), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 109, DateTimeKind.Unspecified).AddTicks(6743), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2958), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2985), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3012), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1803), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(1930), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2022), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2078), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(2159), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("359a1d01-5690-4c6e-ad3f-9123800092e0"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("a5291083-ba51-443d-b9bb-6f99a56ad043"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3077), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("252a1228-5091-4081-adb5-60983bc44bf2"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("ae29aeb5-9937-4cde-b0d2-c6de8f9bf6d3"), new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3083), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3807), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3812), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3815), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3817), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3819), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3823), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3825), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 31, 22, 1, 56, 110, DateTimeKind.Unspecified).AddTicks(3828), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
