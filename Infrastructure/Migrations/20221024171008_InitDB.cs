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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("48265f73-94f7-41b9-ae34-6cf50bd72346")),
========
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("41251045-2798-491d-bd35-cef504626252")),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 245, DateTimeKind.Unspecified).AddTicks(9272), new TimeSpan(0, 7, 0, 0, 0))),
========
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 321, DateTimeKind.Unspecified).AddTicks(9156), new TimeSpan(0, 7, 0, 0, 0))),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("caff4c25-be6b-4761-8b4b-53639b0429ed")),
========
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("154f65ee-5369-44b1-aa05-1508a089b995")),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, new Guid("1c630b66-d3af-48e0-b43f-250b6787a9aa"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1698), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("d0391728-7ea1-4870-b64d-7b6b159f901b"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("c5f1a63d-3796-4abe-8376-61f2ec7dab9f"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1708), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("6bfbcbf6-d246-4a39-8221-77000926d51a"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3593), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("a8fc98b3-6ecd-433a-bd50-042a6badcaba"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3598), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("86394f0c-28e0-406f-9196-0ce970513341"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, new Guid("74c61ad3-deac-42e0-9558-b98ce633045a"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("67a04497-b026-4aed-ac2c-728c6319b46e"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("3ac3d1f1-c089-4f9a-8545-ce09e0595c35"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("5f241d1e-7785-45e1-b52d-915e567706bd"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("f3efe304-5a51-46b1-ae9c-ce829b665711"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("c54c598d-7f70-4939-8422-dbd5fe3771b9"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9428), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("20362bb4-7d3b-422d-bc22-b9981197910b"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("fddb3121-6adb-4237-a6bd-a7b6648b5f54"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("f3a9357b-cf51-4db9-bdd8-7b99d6671b9b"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("e24b6367-9d53-493c-a905-069239a80073"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("a16b359d-9865-4470-9bed-e45ea1f29744"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9500), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("170fa336-01dc-49fa-99bb-c0fbf94b1105"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9514), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("73e85d17-8528-4e06-9fea-d092c72c9a0e"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9529), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("fd3bfaf7-f80f-4b6d-8a48-35ac6b825a24"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("269ef213-5f1f-4cd3-aeb2-402cceb4523e"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("db61d8ad-9c93-4f11-8508-2e98206e96e1"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("1609fa39-bf70-4e3c-a93b-e175b9f71f20"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(714), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("f22df19a-6400-4e6c-9746-3c2404fc6ed7"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(724), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("60454506-8fb7-4889-9917-e52055c0856b"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(747), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("8c9a8c04-08e8-425b-b810-a292cfb47c88"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("b297ecd2-b544-490b-b021-b7646c2314a6"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("38eb9a72-7852-493b-a4f3-fec754077594"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("3ac15113-b69c-4667-8bf8-c2c0e5cdeffd"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(834), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("1fc6fd5e-a2f8-49dd-8ff1-7104d5e120c0"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("f6c66a90-6ac6-40e0-b626-754f9790324e"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(857), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("5add1996-e4ff-40eb-95fb-4c80bcafe9bd"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(866), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(264), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(278), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1448), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("9e85b139-87c4-4083-a896-58c21f780abe"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bb531d0a-d09c-48ef-9105-a35c74dfe54c"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(753), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6a92103-65e9-48ed-b476-310807b501cb"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7251d302-67b9-41aa-b185-f3b1e8cbcca7"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("41e0c2b7-c6f8-4f5d-b6d0-a8305d077501"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("08f7ec77-7f74-46f0-800a-b91b4d2cab5d"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9add577a-0d9c-4f0c-b384-2de192b0cb88"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e6a371c6-2e9c-410f-bcc7-b423aa307193"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("42d9de0a-5af4-4cb8-9540-7b0e5e9606cb"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(784), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("2655874d-71cc-46f2-bf33-fff8a65ee082"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbe5642b-0a5e-405d-b0c9-80345c577809"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(793), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("56ce8661-49bf-41a7-86c4-79495f2fe083"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("486495dc-06c3-447e-a21c-27aff5788752"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("2abb0d65-e76c-445c-9ba3-7c070946dfb4"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("231cdced-1b88-4d7d-922f-5bdfd35163fd"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(809), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0bfbbf26-fe12-4c1d-8564-2e7bbbb10664"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8b1d9dc2-3be6-4682-832c-6691fde88425"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4efd76ff-4e17-4d38-a07d-f1e7e4fa3d07"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a7b23d3-d5dd-4fdd-8294-be68d89d3a89"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ee2d21a2-0522-4565-994c-7625823f9053"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6c7c8900-4865-4688-b836-740b720aa828"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fca608bd-195c-4862-8015-3ea9338933fd"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(845), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ce2eef1c-2a70-46e8-be27-4e5f1d95c793"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(851), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6e454994-76c3-43f6-8235-7a86018dc00a"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(857), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f5ee935d-6676-470c-97d0-516417f3b335"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(861), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0ceaa23a-0c8c-45a0-b713-e8931316c38d"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(864), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8bd466df-a666-4a60-b42b-7eedc2b0506d"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(867), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d47e7fed-26f6-4089-b60e-a496466eeb56"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(870), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c8bde609-1531-4927-ab4f-1ac4a54e64a0"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cbd4b6f5-15bc-4ff3-8686-b0dc5bd035d1"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("291f8f98-ec19-487a-aed2-ff156e91c704"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("56b68534-0212-4407-8f51-313f9f11cd38"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(886), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1c1625dd-d3a3-4bf9-ba25-25be938d1b34"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(891), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("61ad4382-e7f3-4647-9d3c-018031e035b9"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9cac2376-afae-4ed3-8182-0aad9b6ad425"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("96f9af97-3f0e-46b3-8b14-cd5baa567897"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("0fdcc5bd-6f81-4f55-8d3a-467326cebe7e"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f247b7a9-06e4-4b04-bdd8-113f35d801be"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2022ee61-d44f-4258-9288-cdcc616b515f"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3444deb0-e1ea-434f-8e66-eb0521602c4a"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(919), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4e4051d9-7b84-4abe-8d9e-ff6024b382ca"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(923), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbfc88e5-8266-4357-ba3e-311a9711f3ed"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("a519e934-7db9-4da8-9f9b-64b7c3a534ed"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(930), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("536b7941-7e38-44c6-82c4-231072c7a9e4"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(933), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c290176-2a22-4491-b017-484883434d1e"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(938), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af478121-77b9-4e11-99a3-00e435f3af6d"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad9707c9-3209-44ef-9fc7-c4bfa85b5af0"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb7cb779-3059-4b6a-ba05-8b4ea2dfe298"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7e1c8af3-9bc0-49e3-836a-8b0412657db4"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e742333c-6faf-4e52-ba1d-84a0dfbbdb47"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(958), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f129507e-298e-4f88-9884-d8f80df3d3e7"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dcbf80b3-9c13-4df5-9fcf-bc350e21a645"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(965), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("60fb0c63-8c71-4153-9df1-1ef038bbe696"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a075bf4d-6b02-421e-a7a7-d963e81d5ff6"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(973), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af892759-f31f-4ba7-a32b-48b3e67d2e04"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("70320146-396e-4c93-bab5-f4b056ee449e"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9bcd5723-e5d9-4c77-940d-ebefc5efe737"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(988), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0cf55cf1-4b2c-49bc-8f2b-eb1cd393a9a6"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d639f0ab-e74f-4acb-99f7-bb187eeb57b6"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e0344f8e-b205-427e-89ec-2dd395edf8e7"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("db0e0eaf-8f48-4f61-ba8e-e957784904c5"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1002), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3fab965f-c99c-40fe-bd49-e2652bd0d157"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1012), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("833fe7e8-1982-4500-a1fe-496a6ca9ee27"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1016), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3997283b-7976-48ec-8c4b-ab3e06c7b595"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("85cabfdd-23c5-40e9-a4b6-ba7e2a49b3fc"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f347e976-23b0-46dc-be30-930f014676ad"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8996fa56-f410-40c3-b0dc-9cf2e0d7f650"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1034), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9cbd8e29-9fb2-4f98-a145-01f8b6a5cd51"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e85db617-0d25-494f-b0cf-ba82ee8177ff"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("980e86a9-806e-4768-a085-70a5e5ad73d3"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1045), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("884a5ce3-48a4-4b34-b25c-ff279770db5b"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b7665eeb-acb1-480f-988d-b5361c886b5b"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1055), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f76ce193-f5e6-4b2a-9768-b2333ad99e93"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0373966f-ca65-4d42-8e15-d279f6452fac"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b28fb44c-ce44-479f-8290-babd72441bc6"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1066), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a2d140b6-049f-4d33-94de-c7c5c2e084c8"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7df96e0e-41cf-48af-bfbd-7ec7d34f3198"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1073), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("93a30f89-b93f-44da-b3e2-d74da3e9feaf"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1f86ed93-0d27-48da-a8f6-517f898e6d62"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1081), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("66cc62ba-34af-464f-ae09-558d469707cc"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ca5c8645-088d-4e1c-b0c5-147b66c8b29f"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1091), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("cb6ff565-dde7-46ff-9f9b-c9634a9b0b03"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("c1ee21f9-0199-4388-822b-ea2c3595daca"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("99edf1b9-66fa-431d-bf7d-ab7dde71feec"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("32a6bf8d-48e5-41b2-bb29-41e523c51740"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(848), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("f295446c-63b5-42a0-ad0e-edfd696b560d"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("6982ff52-8297-4378-9dec-783d2a77eade"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d4cbaa91-daf7-4630-a2ba-db7efffea035"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2146), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9bce7fa1-3641-4681-a9c0-67c9154a6acd"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d32c941-1676-4de3-93ed-2399d129f325"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3fa46a96-81f2-4d84-8ccd-2099688bf1ce"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3fe22bd1-7b3b-41da-8250-4645354e3751"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e34727e8-df3e-4a68-88e1-d3e38fed9b06"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2169), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9070e3d5-49dc-4639-bde1-bd782f3844b2"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("bf450883-9ba0-4300-9b3c-b0d4131b32c5"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2182), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("87c6f808-90ef-4dc9-a8dd-a99f23ebcc16"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2188), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("676bf53b-b618-41bd-93a9-8d7317b46c7e"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2193), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("44bd895a-90d2-4497-b055-3b9a8cfdb41c"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("62a8d760-9599-41fc-ac27-26e1739b3369"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("469a022e-7d91-4e64-afd5-3f1a8bf56785"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("883e1e5b-15a5-4ce9-80fb-6a79f52a2b99"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2211), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("92600f0c-642a-497b-9932-1e7a62b98183"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fab8213d-8320-453e-8028-50dbc6c391ef"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2221), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("50825ba1-6828-47ed-aa94-5d40824ddcdc"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df688ef0-790b-4d32-9038-fd2bf44bc870"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2231), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a95a418e-7ad8-4fc9-ad1c-c915f881a216"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eaee29cc-535a-41c1-857a-04c674271f4e"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c02786c5-598f-4dc8-850a-7411e7d9f9e8"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7a792de-7b98-4ad5-9301-41aa85b30fad"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2251), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d9573ce7-41ad-4756-bc44-0d497e0d1bcb"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("387dbbc2-4aec-4885-b3ca-ae838aaa65be"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b5387511-6e14-44e6-93e5-b67fd0309aa8"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("310e8dea-27ec-4fd6-afc6-ffbe38853dd5"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e9ba013-1397-4769-83a3-e4c1168f6b11"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("42ee7704-5742-40b7-9d04-9582c0911a55"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b8629a4a-fc82-4070-a159-7a2f939bf13e"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6a02e95d-c3d8-41a3-937f-663c2aca652c"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("95f31c72-a801-461e-bf0f-a3bb5e81b0d6"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2293), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5ff75dd0-f490-4924-8fb6-abb1226f266f"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0a91abf7-630d-4b67-b027-43eec9a914c1"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8e2f63c3-f937-40b5-861f-ea7688c368c2"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad1364a3-be32-4dd9-b9e6-a1778d5197bd"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("1362ad0b-b026-464f-9e21-eb438620b209"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2329), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6364852b-9d48-4d81-9b14-cb92e357b406"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a3604e2d-6961-4cd0-a98f-f14e4cc57cf3"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("19557b12-15e3-4fe7-befb-00118cc74079"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2473), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("708d8eab-9eff-4698-b52f-d011b0ce8dde"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4ec1762d-cf29-4d4c-9439-c989bea508a4"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("eb539f45-b647-4252-b731-758056d270e5"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("8c5ed570-c6f3-4166-ad32-be392a0cd281"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6a5042a-8f8f-4f9d-a7ec-e477060e89c5"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2525), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbd1f9cc-d1dc-4a66-a500-8ac95e5c1842"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("01c01a34-ea48-4d1c-95a4-4b616e706142"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e985fc28-35af-4cc6-9e65-1a003577f67f"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2541), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb5d008b-c972-4727-bb1d-aa4b65fa6686"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2545), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4db176e3-7046-4206-8755-711c7f643f56"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ab1a614f-b373-4e9e-8e23-2825d43a9668"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2553), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("18490f21-4799-46d1-baa4-36266fd101be"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("365b5ee9-30b2-4cf7-8d48-98fb28c142fe"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6a716e42-e34b-4794-94a2-6522b8a2519b"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2567), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4ad0ec85-6873-4043-b044-210bab319420"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("61b6e2a2-5336-41da-8248-aa3940da7ed4"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4516956e-1a55-4db8-bba6-417ad3237b32"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2591), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f9f0393d-c894-489c-bea1-03dc5631646d"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2602), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("77a6c450-1cde-44f3-b985-82c9d8d3a712"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2612), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("237af5d3-7036-4dcd-9dce-00c5316a6b19"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4a1eba9a-63be-4cfc-92d8-906bb594df4a"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e64c815f-d851-4761-b3c1-a85f8540bd37"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2642), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d020801d-fe6b-4c43-8bcb-ab0502f141ea"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a2a9644-8c46-4501-b57a-b4a763607aa1"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2656), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1735aaee-73e8-437f-807d-341e66e8e7ce"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2674), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a79b19d-2ab6-457a-ac22-deeb36864f80"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ec152fd3-6130-4dfb-b03a-a6c5593d63b9"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e1cdfd13-2c4a-4050-88ba-f1325f0087e0"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("79b2eea5-9286-4e91-a181-377eb89ae0b7"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2690), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5360cfcc-8f8f-4951-a97f-5a0e0a9ea68a"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("c57cdcdc-cf38-402e-b174-ee1fc0a281f4"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2698), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("64fca027-055b-4e3b-b187-8df2d25305c2"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e689a20f-98e1-4b1b-9dcd-98fd9fa231fd"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2709), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aa6d96ca-e48e-49a0-8a93-8c0323e855af"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("410d11b3-d3a3-4dd4-9ad5-3358633344b2"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8f08fdd0-a9a5-4931-8996-f2b676d6957d"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("219b0fc7-bd85-4457-9f4b-e8b6984f5eff"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4bc41fee-f102-47a8-81c0-854ac5fc29e6"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e96a93ba-67be-4e5d-aa1e-c2c1c6beaa27"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("653dc4f4-4dfe-4835-9664-d0b76d4daa0b"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("fdaf7bab-3e3a-4610-b08b-721f2cf9d1b7"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("7e6403aa-8f7c-4fb6-b285-96435617ba1d"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2825), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("178bc62d-3fc6-4e75-9d13-671495d599c0"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2828), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("db1b0cbb-fa67-4790-b874-4c38f5fa6463"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e899a5b4-739a-43b8-b220-229686aa915f"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("c5258cb2-7cb9-48e2-af66-8cf02ae906cb"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2836), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 10, new Guid("c30f4a52-5ca2-49b5-8801-4e083c6ae1ec"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("00355fd8-4833-4ec1-8944-4ca729dbca97"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("1571b445-f62e-428e-88cc-aaa41f7b0142"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9772), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 10, new Guid("d61836af-d255-44db-85d9-f75ab216ce08"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("0f796490-a19c-45c8-b0cc-a55f86e062e8"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("7418e3bf-e050-4179-ba03-1c6811692faf"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1092), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, new Guid("ed0c58c5-c577-4603-ba9f-93fcde791993"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("69da31f6-2465-4691-b269-3abbf53c07b0"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0b536068-32b0-41ce-814c-b22ebe12259a"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1314), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("0622685d-2b1b-49ca-81b9-c3a651f69a6a"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3015), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("eb21aa81-5f40-4065-8fe4-161006e27b79"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("5e026d66-dd38-40df-92a8-f35cfb3e8a1b"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3097), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });
========
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1307), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(133), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });
========
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(145), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });
========
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(157), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });
========
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1380), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(171), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });
========
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(183), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });
========
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1159), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1166), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1179), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2905), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1330), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1338), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
========
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3148), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3151), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(500), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(553), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
========
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1746), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(236), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(293), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1415), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, new Guid("12e3e8e6-0a2c-4ca8-b327-1ad643b0fe46"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("b78422af-dfe6-4181-90bd-e22722b3cacf"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("f720bad8-5678-440f-afaf-825474a5144b"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("725faae4-bc96-4a91-a30e-20ab98fc271d"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("6e775398-cc83-4b88-981c-331fce4e7150"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9646), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("5e82829c-8a09-46a7-806c-82cd8b6041f2"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9665), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("fe282780-8362-48c8-a9eb-45ef5082c7bb"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("87f75be7-9055-411a-946d-b5d86ff5bfc1"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9698), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("8f3da078-a8ad-4053-a440-98960ec439d0"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9718), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("74a4a74d-7121-4bcd-8e24-58ce93338ae5"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(893), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("72502f2c-f622-4a25-968a-d4fc8e94fa63"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(914), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("e1ba8335-4ddb-4bd0-84ed-44464a419761"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("885df8d8-3dfb-4ff5-87c2-e60d75c0428e"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("272f3519-3016-4565-8768-2dbfedaf562f"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(957), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("922c153a-946b-4606-99ec-10b68bd17ebb"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(971), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("21976600-55f4-46b2-8268-0d42817c576c"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(982), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(983), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("14f6d80b-3d70-4213-afa6-042c2c5df745"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(997), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("8109adfb-e9b6-4aee-8f8c-86cabc6e893d"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1012), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9795), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });
========
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9850), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9864), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
========
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1142), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1152), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9890), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
========
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1161), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9941), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9956), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
========
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1180), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9969), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 259, DateTimeKind.Unspecified).AddTicks(9981), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
========
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1199), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1208), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(3), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(4), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(16), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(17), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
========
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1219), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1228), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(29), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(30), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(42), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(43), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
========
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1238), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1248), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(55), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(56), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(68), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(69), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
========
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1257), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(80), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(81), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(94), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(109), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
========
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1275), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1285), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1295), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1487), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1531), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1553), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3209), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3325), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3333), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3352), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3435), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3460), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3468), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(321), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(462), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(586), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
========
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1674), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(629), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });
========
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1813), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(659), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });
========
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1867), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(682), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });
========
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1940), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(703), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });
========
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(1989), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, new Guid("d8726454-b5e1-4931-a4b8-ad138adfbd03"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1624), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("fefbcaec-d740-4e31-a5f0-c6a338122831"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("7eb7a974-0872-4727-bd33-19560f16bc7d"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("c12523a5-6491-4ebc-802b-0ec15d09d65b"), new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1637), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
========
                    { 1, new Guid("73cc0307-133e-4a3c-91c6-5a72326f07d4"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3538), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("effbebc4-0fa1-4430-ac9f-71f2de8a5efe"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3543), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("a4a1ba38-94ab-4a58-b6f6-7355a24f5716"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3546), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("c91d428d-2ba5-4a25-9fde-f71c778f81f5"), new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3549), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024171008_InitDB.cs
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1785), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1789), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1791), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1793), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1805), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1807), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 25, 0, 10, 8, 260, DateTimeKind.Unspecified).AddTicks(1810), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
========
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3623), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3629), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3631), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3633), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3635), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3639), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3641), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 26, 0, 8, 3, 333, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221025170804_InitialDB.cs
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
