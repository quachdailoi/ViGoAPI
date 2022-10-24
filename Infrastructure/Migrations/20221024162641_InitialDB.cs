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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f35d7166-56fa-4a31-b1dc-5d3bf5f6b6b0")),
========
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("23853ed2-3d87-4334-a36a-5dd92989f289")),
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 370, DateTimeKind.Unspecified).AddTicks(7210), new TimeSpan(0, 7, 0, 0, 0))),
========
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 450, DateTimeKind.Unspecified).AddTicks(1530), new TimeSpan(0, 7, 0, 0, 0))),
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("0feda1e5-c761-4f62-8d86-6acdebcd9342")),
========
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f5741b93-3a9c-4736-a255-19221a7bdbb6")),
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
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
                    status = table.Column<int>(type: "integer", nullable: false),
                    TripStatus = table.Column<int>(type: "integer", nullable: false),
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, new Guid("2642c15a-573d-488e-be48-264cf744d7d3"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("0a5d9bc1-46d9-4fcb-86b3-145b18b6fdb4"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3922), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("d8a1e9be-b590-4bd5-a85c-a38e6a144160"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3924), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("0300cd71-a1fc-446a-980e-a5c39a43d094"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("c4207b70-df64-4f62-9010-0e651b7199cb"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3686), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("d194948e-023f-471a-b964-b6dd8d1920ea"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3688), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, new Guid("69343358-a3fa-4ad7-bff4-9a0a6b8e7cc0"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("1067bef8-9f78-4d7b-a4fc-601a48461d86"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("4e5b873f-4189-4a91-af27-3fa7640843f5"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1844), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("21b463b0-1419-4dca-b537-410da569d8e3"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("adabd750-1fb4-4a07-ad84-be79aafb4f48"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("762d6db9-be69-4d5c-bee1-e04c000ee874"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("fba589fb-79de-440c-bf0c-f18dbe7b0f51"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("a9194fe3-db75-4b62-87a5-d5709ef558ee"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("6c12f4f4-23c7-49cf-9086-f7a4e7cf23f6"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("d73f138b-2db0-44b5-8f3c-8dc27d7f4b1c"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1973), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("ab8342ec-3670-4ba0-b462-266f39ded242"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("bcaec453-0f63-419d-94a8-66bffb6b3c0b"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("befa9897-1129-4386-9720-d645696576e3"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2006), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("292cd89b-be98-4b88-ab6d-ac7b5e2ea5b7"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("6c6d6b41-3e79-4024-8c79-e2eccda20362"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1748), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("b5de4210-1bd9-4f11-8802-fafda7f86aea"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("4188a6c9-44c2-4ad7-bb13-6d593b2126f0"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1772), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("2d907be5-f406-4f24-bc33-3087e7d47fac"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1793), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("c7f80ea6-1789-4510-8f6e-cf9ed82f4eb7"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1808), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("3c817661-db5c-4328-98bc-2ab53096d7ed"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1818), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("0182dfbb-e887-47d3-bc25-f8c1c0b1508c"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1828), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("2ee5c37b-6709-4cd0-94cc-71b93fb6ecca"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1838), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("40e40469-bc96-48ad-97c0-859a4b80151f"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("29001ebf-8c88-4f7b-a97c-0b98093e2cc7"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("46813d19-3640-41d1-9b10-020aa2c75a40"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("9c74d3bf-2575-4c7d-bfc4-ca51ea49a83e"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2688), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2697), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2441), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("c31e6978-1e2b-4506-b507-8c47b7ea5cca"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3104), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("410b6e19-b56a-45f3-8cfe-059fa0707858"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("418be49b-768d-4955-b763-80ca5d3fa845"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8573e579-324a-43ed-9eeb-2dd6d7eb1acc"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3116), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("caa0e8dc-2502-4e3b-8604-399d611c7617"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ffd1ecd4-0145-406a-954c-e3d8aab4eca3"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3128), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("828237ee-92e5-452f-824e-0ad3f9dfaf77"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0df42dc4-0920-4c68-9566-a127cbf74368"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("bf60d364-df05-4463-aa14-08ef3a30ce3d"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e35a22b9-3e26-4ad3-acb9-fb1a1cf3b21a"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3141), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1288493-7a92-479c-9e5b-ddc50a1426cc"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0899e570-4839-44c7-b59c-78e93cd700a8"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("81939bad-63ec-490c-bf23-55c5703b4d23"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("f59fa787-571f-4430-a5a0-c66d78b04508"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3155), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0663b232-089a-49aa-9676-fe59981df67f"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ab229b6b-0d91-488c-961b-16a5bcbfb1d8"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("58c03273-5a57-4b84-877c-ff1218b4ac9b"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3164), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7e90eeb7-ec2e-48bf-ab83-ef52a2a10b21"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4245d740-ef6a-48bf-8ee3-578c4a59b280"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("01973924-9377-4a2c-a3f1-b46617b22dfc"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("96d61b50-2f28-495b-a9c2-0f2354fc987d"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3177), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5867996c-699f-40ab-9d9b-993a45f9ee70"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3182), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("636ff997-87c4-44e8-aadc-6766c3ccf2e7"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("361f116c-9c3a-4e11-a194-acee749d36ca"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3191), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("90af7085-816f-455d-ad2d-50fbb4992403"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3193), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e19349b-fe6a-4168-ae58-3c6244100ccc"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d3c53da3-dcf6-439d-9aac-8751c6e0917f"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3199), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("72982086-7a8f-45de-9eb9-bd38bb485147"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("41de9183-3832-4e64-8fc9-97cdeb2bceff"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("06b2c929-2ef6-410e-99e5-acef371cbf78"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3210), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("44029ffe-7417-46cd-ace6-de77d8b37672"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5405e1b9-d645-4fdd-9662-2253f3b6526f"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8a7b4d94-a025-491c-995c-eba2564e94f1"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bd83d109-f196-4595-a1b1-81513328cfeb"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3223), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e19c1c34-0537-42d0-845d-6f111355f156"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3269), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0c8d5ee5-935d-47b3-9e59-9ab436b4201d"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3272), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("516ec997-b7f3-47ca-a314-b00116f427d1"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("584bbe12-5d85-408d-a522-276b3e074514"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f1f7fe70-497d-4e5e-801a-60d688b8bdaf"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9121a500-549b-468e-aa7d-346586f40c47"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0fd79889-bcf7-4fc9-a2f4-2a8157e37e0c"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3287), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("516715ab-22ec-4a26-9bdc-f5f924aa9ab7"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("091023b9-f341-4338-98fa-7a5ec03afc60"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3293), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("810a4b55-c364-4c0e-90b1-f76e81fd29af"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f646bcb5-1850-4192-aad2-e1f5c599e37b"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29462ec7-29b7-48d4-88b5-47fd363efddf"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("06b9d71f-46e9-4e86-ba97-4cf2470a559a"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3306), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("89febf9c-0ac4-4b25-90fa-f54cec52e9d3"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("320135e0-724b-41cd-b793-b43d6f182420"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3312), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fa43f7ba-8d17-4644-a424-2e6bce371ff9"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7535f1ea-c5d6-4b8f-a901-a1199785c0b7"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3317), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9e806896-eb9b-4a62-80ea-bc0a738c7206"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("161411b6-0a35-4a16-87fd-a7bc6c63c154"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4d3ec1d5-3056-4cab-a5ee-17aa419b6fa9"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3329), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f5277957-26ab-4ddc-a7c6-c63667f686c5"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0194ca40-ea61-4650-907b-ac37f9451e66"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3335), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("255886a7-d3b3-4649-8ed1-fc6a91f82cd8"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3338), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8ad57d3d-1f5c-4182-ac7c-33e01519086c"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3340), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("747ba087-bad3-4cf1-9429-3ecabcc61d89"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("841df430-857b-4113-9e5c-4e58c34f8749"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9bf806d2-a26c-428d-83ad-3f9143c3bc57"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d986f3de-cf6e-463e-8a99-eed44b54ea98"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b084d685-7869-41c6-a7d7-73b3044582dc"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3356), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ebab9b12-1566-4233-b9a0-dab37ddb6747"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("050443f7-b1e3-41c9-9622-c9eecece71cc"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("420ded40-9fa1-484c-bd96-5a99e08f44c9"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3366), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("12468a41-22b3-4416-b3a3-fca989c9fbac"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3369), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a548e576-cb5c-4818-a990-f051dcefc0b6"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9df1a73d-c626-47f7-bf4b-421f97d6885a"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3377), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ff408a7-7195-4321-b788-9a3bc0d93be0"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("4217a753-ec5f-4c43-b25d-428bbf536f2d"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("27919bc4-d0e3-46d6-97b3-0da977da6ebb"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("44a1e23a-420d-4be8-a7ff-7c0cf11baeee"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3389), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ed43341-f2c5-4b5e-8b7f-8f5d766ecc75"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0395bf5a-2f74-44cd-8d8b-f4108020f39c"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d231e5f8-87cb-40e7-807b-a2fecd4b01ff"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("16f65b51-7d40-4131-bf47-3ec9b3ae86c5"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8301bd2c-afa8-46f3-8041-e6bf77fec042"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e4392ea6-9d21-462b-88d0-a9543be68e01"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("08f88938-5977-4dd9-92c8-42e8d82df3f6"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("db7cb13f-77f8-4be7-8988-0cf831524ee3"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("cb06df4b-f69e-428b-9895-985dcb6ea12b"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3460), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("546b9cab-dbfa-4d19-9383-c8526b1d09e6"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9cc691ec-e05b-4e72-a517-2cbdd2d0d82b"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7c7720ed-049d-48b8-a653-f47cceba1a56"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3185), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("49047f2a-6f67-4135-90fa-fc8544a88159"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3471), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("fd81ac3e-7b21-4b12-a8b3-55a28e7f9883"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("60269c75-7fa4-41ae-83fd-7abfef9db429"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bd4f7b51-adba-40b8-b748-5c53622e29af"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2865), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a8607c31-69cd-407c-8107-ebb008744dd6"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2867), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0630396b-c8b1-431f-abe0-f1c943493633"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2870), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b0ed957f-6765-47cb-9ed0-6c67dd5a6cd5"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2875), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("691b7222-ebe7-43f2-b484-44554809c75e"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2877), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e7c4111-3699-4970-bdfc-9ccb969b713d"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("0f4ec9b8-dbaf-4f77-b725-1b5443983485"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e32ec508-a966-4a3b-afa9-fef8f25d229f"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2892), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d8ba81b6-6a3a-4e07-b836-5674644d5b19"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2894), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2325a530-2468-4d78-a854-28d23ed927d4"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("02ff548f-8de7-4225-bc17-d3c76950b465"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2901), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("ae365e58-983b-4108-adee-f5cf1ac6a4f4"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2903), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5b392234-564d-4fc5-a3f4-91687f71018b"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e0dcbf2d-a142-436d-a6ff-e9e5246f87e7"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dfe33f32-2bfb-42c3-9f59-da3c5231edf3"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("50b09090-a1b8-48f7-ace0-1ccf5fa93aa7"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2919), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a0e43b98-59aa-48a7-93db-93635f9673e4"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c1bd5fd1-6d8b-413f-ae6c-86f803b43d59"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2924), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4174fb65-2363-43d9-96c4-bb4fb72cdab0"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("960ad71e-d461-4b6c-8677-3cd4fab00258"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2929), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b41860b5-4d3b-41b9-bfb2-41a56743b854"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2937), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a3c51f7-d20a-46eb-909c-856ac2e13ff1"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a4a7f405-6390-4e8d-9b46-8cb338d9355b"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2f7b9c36-a770-4b21-84ef-5079deb73163"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dfc0fbb5-38a8-411a-b612-ce8943bbbed2"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5585a3b8-132c-4179-975f-de6abf57d6c0"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3018), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cc86eca8-9971-4b52-a2cd-290ea6719aca"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3021), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5174431b-adc0-4245-9517-ca51ce62c8c9"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e3210ab-c54e-4d0e-81a4-8185cbae7046"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f63ba534-dd82-4421-a5db-63d436bb1a2b"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3032), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5ea44897-6076-4f38-9158-3b3627686147"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("51fd1d4e-6783-416d-bcb5-7e73e26364c3"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ab339d24-3267-46b8-9cdd-f2f7bf210bc0"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c5ff1446-8f44-4d70-8142-4e23e59aad0b"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("5554ee42-0eef-4b1f-ae4d-e15025b35982"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("37c580a6-b594-4839-97cf-524e49971600"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af44b7ff-2c41-4870-9f16-1f3d91a49fb1"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("875b41ca-e7ad-476a-8f3e-d9d6c91942a4"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3061), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d453216-e817-4ac3-98e4-8674ee7bd192"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c84cb34d-ac8a-40e1-8ecb-5ea61ac4cdf1"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("b1874ff2-70ed-4f64-923f-981bd0646a33"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("d297ed5a-8921-4301-b5e0-d92dc2933340"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("62420b32-0ecc-4593-ac0a-c6ca1a2c53c2"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("51a282a0-bd28-4a04-939e-302768ed446f"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("23182882-ac08-48f0-8833-f8b7181e14d4"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8513ee3c-c765-4684-8d57-c23e932d2611"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3085), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("95670519-2e2f-4b41-a164-2bb3d6c65251"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbbc42c3-0b6c-49e5-9a9b-43aba8b622bf"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("244a2c61-1761-4120-8315-648277e826f8"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3093), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("949122dd-d3de-4d46-9b5c-a3618b3d2ceb"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("10035448-eb5f-43d1-b988-d3ae06099c6f"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ef07bf40-f3c7-4156-bd56-4c43653ae12e"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1ec63946-b9ca-4cb5-9c24-0f52e47ecbdc"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("209d33d5-ab93-432f-85ad-ed3d666d1f4c"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3109), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fbdcf51b-e12a-4818-9f17-7b0d92da7cfe"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3112), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13020993-e533-4665-a533-d8ee5061b631"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("004153ae-8dfb-42c0-b8e4-49726d9009b7"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3118), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("de2bce89-2bad-4f69-9606-582746313504"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("031984f2-f9c6-43f1-b77d-ff164d833f90"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b8739a8b-394d-468d-ab2e-c96aea17e4be"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("57a60815-91f3-47dc-8709-a4fb4c88275a"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3132), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d1f5181b-f973-46b3-8cf8-10ba7e4540c0"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3135), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f26c4f9f-2597-4b0d-ad4e-bb429888972d"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3198), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dc9ca668-de8a-467c-a4c2-9fa1b9dae834"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("994854d5-f858-46f5-8b89-1eaf90542ea0"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4bb00e16-be94-488b-a9a8-534254a8985f"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("87810830-0003-4db6-8f3c-91a7ff76c3f3"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3211), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("40d79246-05fb-412c-b7c5-e7ef20c9c52b"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("703617a1-70d7-4a22-8a86-527aba8d78d4"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f83ab1f9-9ea7-4411-b420-c9f359244b1c"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3221), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fd7bb7f4-ec99-49eb-94b9-822ccf581780"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("91b21def-00ee-463c-9040-ead2092dcd72"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3227), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("42573dcf-5896-487b-af44-b7b49b3c2106"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3230), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aded3228-c4f0-400b-b845-12d780781a82"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4a6d0874-a8e0-4e01-abba-361342646baa"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3235), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aba9de49-56eb-469a-923f-3d74ff226a9a"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b45c26e1-7738-41f1-b603-2c9cb6ed3fd5"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4b8e1e9d-bd7c-4314-a73f-1c9a553d4c02"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3248), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ceaf6089-5439-4cea-8778-205447b7fb27"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3251), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("eececc30-7755-497a-9fa4-e300e857b892"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3254), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("55067db1-635b-4093-a171-abde8f7f5d9b"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3256), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("8606015c-d6df-4477-9706-295394da7bfe"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3259), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("322018a8-39ea-4218-ab32-b2d69f83ff6f"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("a338c92b-05cc-4bd8-b3e8-de19b8406304"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3262), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 10, new Guid("2a2b36a5-d4dd-40f2-b80e-be7358df8b0e"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("8c06ed67-ec6c-413e-a6a4-63c1e19edffc"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2211), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("10673a8d-f737-4447-9fb0-42c6658e797d"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2226), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 10, new Guid("07ea7ca2-c8fc-49de-89ff-ddf53eaa3b31"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("bbc38bd0-d72d-4f5d-8076-82842f69be74"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2081), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("1af9895c-6bf6-40be-bf8b-f57bae98dc82"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2093), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, new Guid("c9812648-8110-48ba-9444-960f62b828e2"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("0d296039-02a4-45a3-9aa9-c7a453b0a00e"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("5c52e255-f5de-41df-b46c-407ea220dc60"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3598), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("731c867d-986f-46fd-babf-9bf2e55c1aba"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("8b1bed17-536e-4b48-8b7d-d9e2de1c4492"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("d84f3a68-5c48-4d00-b017-d312f270c99a"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3435), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });
========
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2598), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });
========
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2357), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2607), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });
========
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2366), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2615), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });
========
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2374), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2624), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });
========
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2382), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });
========
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2391), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3517), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3522), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3308), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3312), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3614), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3617), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
========
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3445), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3451), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3454), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2877), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2922), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
========
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2625), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2716), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2650), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2708), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2460), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, new Guid("8aaca05e-0c15-4c02-87b7-ab19959c4656"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("76e25e8c-ad3c-4b71-9f4a-227d3eeefb44"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2047), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("2721b357-e9de-4c60-b473-ac4f785e6d71"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("95c8eddd-a083-4c0a-8f71-c28e9ea36cb1"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("9e8a1145-0099-4ceb-9051-1598cf12dfd4"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("9dee59fc-7aba-4133-b2d5-76a382671762"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2101), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("39745ed9-e8d1-4750-8a21-e0cf52f7ab92"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("114ba7ce-5151-4b20-a39e-4902c27f8767"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("60174760-02ab-41ec-98f5-d0b93e1f2e82"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("bcff9a1e-4828-4e62-9046-4e9659d1bafe"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1905), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("7dfbf58c-8264-4e59-a353-6782195688f1"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("204b4709-e05a-469e-b543-603c014955a0"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1933), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("d89a50bc-78e7-4981-bb99-0b130bfe9c73"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("1d188f3e-2b80-43c5-8307-54737b46a9aa"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("b85babc0-24be-4358-bc48-9ee92660fbe8"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(1974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("f8963c38-ddf0-4dbe-b2eb-89a9425bfd98"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("e50f215e-c0f2-482a-b105-abe6a2d11ece"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("7fbfedcd-1787-444b-ac0a-df8cfd3e9eb0"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2055), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });
========
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2116), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2279), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
========
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2151), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2160), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2306), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
========
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2169), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2178), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2317), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
========
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2188), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2199), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2335), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
========
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2217), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2439), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
========
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2227), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2467), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
========
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2245), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2475), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
========
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2493), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2502), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2512), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
========
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2328), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3638), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3698), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3766), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3784), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3801), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3810), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3835), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3471), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3526), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3535), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3593), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3601), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2850), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2947), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
========
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2477), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2744), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });
========
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(2996), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });
========
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2796), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3013), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });
========
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2813), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3078), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });
========
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(2829), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, new Guid("6954fae7-e7b3-4518-bcfd-81924e411a44"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3867), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("6273be4f-026b-482c-8bf4-bf8bf5f58b9f"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3877), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("c74813be-15b1-4c80-864b-838799f02b28"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3880), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("aa410a34-3949-49e0-9801-1f938225e682"), new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3883), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
========
                    { 1, new Guid("86ac89bf-e22b-460b-a63a-2f710f51c3d9"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3638), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("95d6f134-c46b-43bc-b006-107e0eb2f5e4"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3644), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("53a458fd-f967-485b-bfe3-b274cfda908c"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("fd114353-2832-459e-95e7-9d5cf2adb5cb"), new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3652), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221024162641_InitialDB.cs
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3943), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3952), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3955), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3957), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3960), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3962), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 24, 23, 26, 40, 383, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
========
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3707), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3711), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3713), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3716), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3718), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3721), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3723), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 51, 41, 462, DateTimeKind.Unspecified).AddTicks(3725), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
>>>>>>>> bc7c99a4d9fdf75ba149c8d1ce0f845d244f82b7:Infrastructure/Migrations/20221020095142_InitialDB.cs
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