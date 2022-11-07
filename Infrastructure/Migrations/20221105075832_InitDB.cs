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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("9c038c3a-4b73-41b5-bcef-dd427989fdb6")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 737, DateTimeKind.Unspecified).AddTicks(1785), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("8399acef-1f0f-47c1-95fb-f9040a43c4ad")),
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
                    { 1, new Guid("a429dfdf-ec4f-482d-88ec-d82a2aa78a86"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("e245b9fc-9ace-45df-a522-532656575890"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(805), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0b8c74b4-f898-4867-af98-9626b8750605"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(808), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("bc6d631a-cbc6-42f0-8ed8-c2fbd8c2e806"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(712), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("818dd7a0-2b9d-4ab3-aae4-2323e66be2c6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(730), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("9f204717-c0ec-444b-86f7-6f0e606cb904"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("f117cf5b-6368-4d86-ac96-83e354fdf42c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("94f17a43-6c42-424b-86b5-7a725c8b59e9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("fe49ef6e-397e-4026-add0-138f305b0462"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(815), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("53d95ed0-f583-49e5-ab12-6a875e9c8dbf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(825), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("2805aef9-f5c3-4248-a4cc-cc18429a0845"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(835), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("30fce5f2-a14f-46fc-bb01-4ab4f6a1d654"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(844), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("64bd33f6-a8b7-4be0-8ca9-b52987826831"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(856), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("845f6a73-b113-4229-8508-1d7248e4a444"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(868), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("ddc04b7b-3024-4f95-8f40-6129165bc84a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(888), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("abbd335b-70ce-4177-9809-44b7f772e718"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(907), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("4fc2829e-8d57-43fb-98c0-d1cf6c7a2040"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(858), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("d6c55b53-50d7-484d-b91a-de7a53ebb95d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(862), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("0721ae93-4a67-4473-8b74-c95600565895"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(865), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("4e730bc9-1a40-45f1-9f6d-b53417fb6106"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(867), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9267), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("f96c1bc8-5d5d-4d98-b52a-75c5feb8483a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4c7a8a6d-1b8f-4e3b-9cf0-3803e65c9951"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9677), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9027ad61-7608-4b20-b683-b1b6cae5a7f0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a43fc4ae-458f-41ce-b8d2-0ec194d1258b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("32d09b51-51c4-476d-bdfa-6070e3d71bc1"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9684), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c633d4b-84e0-4d85-8d94-424e02121a44"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9692), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0bd5f898-6325-46c1-bed6-28efe6e11e9c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("090b5fe9-5859-4e0e-a113-4a942bf9b7ba"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("dfa47639-43a1-4e31-b04e-7a68af92b923"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9699), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("bfe855a5-0701-41b7-aea6-ad557916e81a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9703), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("457938be-9190-4989-a9c2-4cb056d8b014"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f97d7dbd-c3dd-4784-8d6e-b154d5c61528"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9707), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("826a507c-d8b0-40ae-8ea4-fb0d5f09d63e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9709), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("8635f17e-9b34-4674-9582-b10cc75db979"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5792a6e3-5db3-4251-840a-72ec957aaf08"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("25673276-dd65-4513-8b37-c2ebfae66272"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9717), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7212a1d3-7dc3-474e-a53c-45e685e8c9eb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9ffaaf0d-ba56-485e-b4c5-8a118c0ac389"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9ef2f460-20f1-4e43-aede-1e0d3c3841d7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f5374feb-da0d-42f2-946e-8a5715fba943"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68f6f206-c592-49c4-b6af-b445823e22b2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9757), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0441141f-2292-4236-883b-f3c1ee345808"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dde6e79a-619b-4c33-a93f-5389cbe3d9fc"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("39c0f72e-01de-4133-a7eb-659bb4c6931e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("97f80e0b-dac1-4e87-b460-16980bcb02e4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("107c8988-b6f1-4e77-8209-9ad2f6a16a2d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9772), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("58e1cda0-6994-41e6-b33e-c7640e6eb656"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d30712d6-9b36-460a-89a9-8f85d813eb28"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0d8bbc88-f683-4175-a894-b41176a25721"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d2b386f0-be8d-4f62-93f5-6186cee9fec6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f89b6651-2cd7-4674-9dd7-b9f58b379d73"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9785), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("40257f3d-de46-4746-852c-06947234e673"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b1090183-2740-4b6a-a72d-42e61bd80c1b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9791), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1df97103-c596-4201-84ae-1b6b78375589"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9793), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("87e27183-d23b-45fd-a80c-b6c9c0b121a0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9796), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("80562122-ab07-4bd3-bedc-3329434de7db"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9798), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("b61bb28c-fd15-4305-91e1-46e7b7664828"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2f247c77-4a83-4966-8898-2957a1901c02"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d92ffd78-5f85-49f4-ad2d-5c3580d1c387"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cf1aa79b-c8b6-4906-b134-6c2ecc756cfc"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9809), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("823e94b2-0ae7-4710-8c42-0018491a6332"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9811), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ba248aa6-240b-4899-877c-eea8178df39f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9813), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("a02f9049-17da-4bea-b8b3-763a4b2d98c4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9815), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("074e4be0-5737-4011-afc6-8eb82044acc8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("239f5cef-9eb5-48d8-b929-99a1c2c940bf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("da349bca-7c9a-4ffe-91e4-0801d20a3296"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ffecf596-859d-4e94-84e3-d5bb043f2839"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9826), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0b83ef26-774c-4ac8-a79a-f6f2e7f2736f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9828), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("abb9c1c4-5190-42d2-8240-f6d210a33bc1"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9d8d1df1-cc80-43c6-ab60-001e66e8a5bf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c67e8b05-8310-427f-afc4-e7aa900a730f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9834), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c2cf23b9-0367-468f-90a0-bd26cbff55eb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aa15f155-4930-4073-abd4-d6e96a61f11c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6448823b-72f4-4749-9fa0-04a6a28cf2c0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9843), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c78a8f96-e088-4cfd-b8c7-83a6443e3230"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9845), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c55aa8e9-228c-4d08-a887-7144fe59c2f2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0f734c98-7b34-431c-a7c7-56922da2540e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6c5aa58-6cc2-47c4-896c-6a6a4dafe50d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d626226-1fef-40e3-b161-2f6f6923eaa0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("41b2b798-2a92-4552-bbbf-e7e1b70f97d0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1bf45d05-eef8-4add-b3c9-b857a98f8a1c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9882), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d0b20b8-7287-4881-9d25-0345f6880faf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9884), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("158147fb-6332-4cc8-bb65-dec81482f868"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dfc1be0c-cd1b-40d6-ad3e-3d72b046bcb9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9889), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("33c282c9-8940-4425-9d2a-b66ebfbdeaf2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9892), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b87cb22b-7701-49f4-8b87-39b113647165"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9894), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5cd5a6a0-fa9b-4ff4-85ae-cee0b57f0444"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4210af05-8570-4f85-b3e9-26b6f0d9e1d4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9899), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2b9b356f-6e9f-4880-83c8-8c249467d1f1"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9903), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("01740aa1-0128-41a3-b943-18628edf4897"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9905), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("1777f09c-ec0a-40b6-b86a-29eff88dbae0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9907), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("deb92d1c-b261-409c-b27a-dc44df717287"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a4bb323f-0cbb-41bb-8be0-c936a1535885"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9911), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1649253b-476d-467d-9d86-4e049c1d9575"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6854d038-f7f2-4d94-8070-3d92772ed2b2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9916), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("890fe0e6-ae87-48e1-8471-466d7c64b914"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8eb077b0-8bc9-4280-8769-e87883b513f7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9922), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f36ed18b-6e23-4499-a1d2-ac9d2a38084c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9924), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("94282e99-1750-4ab0-8316-6a158d9ecfd8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("86890395-91b8-42af-853e-77229110790a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4f3aaf6a-2c8e-4c3c-9f7f-523ae96da725"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9930), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("584a646e-ae13-4417-a321-1387cf34033c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a90e836a-cde4-41b2-84ef-a0485be8e849"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9935), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e0d94e83-84ec-4bba-a280-d1a5a7ce5d82"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9937), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b02ab838-3d3d-40f7-a0c6-fa9c0a6fe23a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9763), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("407a9d20-5173-4e10-aa4a-ce5d8e585194"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9941), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("fed9632a-38c4-44de-92ba-b4544e24f99d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1114), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("92474f36-011b-4611-8c64-2e88fb76f760"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1126), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("3230bf55-75f3-454f-856a-475a8e09246f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, new Guid("110bf2e3-ca7b-43ef-afbb-2e696f631b40"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, new Guid("f5ceec0b-18d8-4fba-9c90-a81d9cf7d846"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1195), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, new Guid("fe48f8a8-d3bd-4587-9ebe-c1376f7a03de"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1222), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, new Guid("83b06f84-5b53-4585-8ee7-3d5b90408c21"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1239), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, new Guid("defcf6c1-65e1-4f4d-9e2b-63b794a29987"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, new Guid("72dc100e-faa3-418c-b965-78ab54228c93"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, new Guid("f6d2ff02-3f41-40f8-8649-8c1b4bfed74c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1280), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, new Guid("85dcece1-7e27-4aaa-a1bb-ad81215fcf84"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, new Guid("661384df-7d47-481c-9f78-fffc98d6ac80"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, new Guid("1f908123-72da-43f6-b79a-c412c0fdc8b4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, new Guid("cc62a53e-2969-4347-a71b-f3ff064f60e6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, new Guid("181c942e-8976-4e89-931d-3c8ebe2f995c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1399), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, new Guid("e64aba6d-83e0-4a61-846c-e5734e0b966d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, new Guid("0ae8d54b-b39c-4845-8d66-9e28edc341ba"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, new Guid("b3cae69b-0ff8-441f-8acf-f4be070c8cb4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, new Guid("0cf79b15-7349-4b48-b992-c3157652c916"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, new Guid("85efb8f5-bfdc-4b9a-acd3-1f996ef98ddf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, new Guid("871579f6-55c8-45d5-b750-f85741991878"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1481), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, new Guid("da77252e-874e-417d-94ee-a5e5ace4b6c6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1493), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, new Guid("6382b991-0642-4c34-abb8-183d6881f218"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, new Guid("0f8eb295-6bef-419e-9003-da68b16bb1f5"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, new Guid("5bb99a02-87f7-4d42-888e-f112a0457c3d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, new Guid("bec4af55-0343-45c6-8bc3-2e607532467c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1585), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, new Guid("c61dc39c-ec9b-45b1-869a-2c7cb2c06d0b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1601), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, new Guid("a7405a4f-7ded-40e7-8c01-7e15a97a8f6b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1614), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, new Guid("271ef0d2-6b12-4efe-a6ff-066cec20326c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, new Guid("ee4b03f3-be83-4d5f-9810-25a9a2b0a7cf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, new Guid("01a5956d-8298-4519-90b9-91e899e79015"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1656), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, new Guid("54c92898-5378-4dde-b421-8773a2f5c7b2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, new Guid("eea90839-6001-429a-866e-9becc46b1ce8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, new Guid("b7330c4f-8c67-47ec-8af5-bd4d2787ebd6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, new Guid("b2dab8c6-9873-4d3f-9a56-aa3bed6e1986"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1717), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, new Guid("7f26b6d3-4c9d-42e2-8431-c1fb714c6ca0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, new Guid("99fe5ba3-6e9c-4a50-b7e9-3b366996bb5a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, new Guid("3172daf6-8b98-4e6a-9248-bc9ace946cfd"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, new Guid("728eacb4-9bd0-4675-8ed7-070789d34e42"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, new Guid("c3de0ce4-cd18-485b-8f2b-b4aeb8fa084e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, new Guid("f08e4096-e611-42e5-886d-67b7ea09e839"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, new Guid("e85d70d5-54f6-4faf-ab38-324f3b4fff84"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1844), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, new Guid("e2681434-918d-4b79-aee3-e3a895143821"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, new Guid("b5585ebe-9fee-4fc2-8ddf-3d37d0a25691"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, new Guid("88b644d5-ba9a-4545-8bff-510e203f817b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, new Guid("44efdd59-5d31-428e-ad3a-1bf680f9ec36"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1898), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, new Guid("c04780e5-855a-48d5-8cbf-300f68f712a4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, new Guid("172943ee-43a6-4984-9d23-d29e91af9f49"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1950), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, new Guid("bef9624f-5beb-44e2-abd3-be82576d28c4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1966), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, new Guid("f12b1d96-2481-479e-908b-42a41729f5d4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1979), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, new Guid("4d1ab447-e66d-476e-bb00-05b367e7dac2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, new Guid("854d0fdb-c761-410c-99f8-cc650a58cfa0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2007), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, new Guid("bf8240aa-de46-4e0d-a2f3-bec9d84c5b7b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2020), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, new Guid("f6042c03-0555-49c8-be60-4625554f2b20"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2033), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, new Guid("e89b470a-e401-40fa-8bc9-01f77fe63799"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, new Guid("86ae034d-66b1-4494-bace-1c46a0893b7f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, new Guid("6decd714-b5de-403b-9814-7a28a1e50fbb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, new Guid("17f24376-12bd-4f2e-8533-14aacf3608dc"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, new Guid("a55992cb-9ae1-4e47-b6d4-da4c3aba90a8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2130), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, new Guid("b768a51a-93bc-494b-9342-4a3ab702ee6f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, new Guid("24946c2b-776a-4845-9949-d2d1ca63e3de"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, new Guid("f7586036-feda-4f3b-bff5-3ec107eb6429"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, new Guid("2e758e11-b289-4096-8f85-5294d2be0cc7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2187), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, new Guid("a2d3557e-9315-4c8b-8576-423fbe8f46b6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, new Guid("27d726a9-5e9c-4ece-a1e4-725b47bf71f8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, new Guid("ccd7de41-5242-46a3-8d15-931d0c1771a5"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, new Guid("41182499-30a3-435d-8d0c-a280b6783f01"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2241), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, new Guid("61eb56e9-fd27-40fe-b004-f8ec7e6b6ce0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, new Guid("8c656275-0b80-4f84-ac3e-61a8d6d3386d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, new Guid("f0ea0532-1a00-4e9a-b394-1484c8735eca"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, new Guid("54540e53-9be4-4a97-b2c2-029bf7ba3a5f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, new Guid("ea912d05-4139-4024-b1db-9a400ff48a82"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2333), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, new Guid("3836b12c-e3c2-45a5-be29-e8ee202cff21"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, new Guid("17056b67-4177-48ec-b5bf-e25ba59c94c9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, new Guid("be2e979b-bab8-4f1c-9cf7-866b249e6dd6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2377), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, new Guid("35172038-e488-4e9d-aefe-390c7019dedc"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2390), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, new Guid("f3d45aa4-51da-4e91-b4f5-b53cb49f6f53"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, new Guid("6580e0f9-7084-4478-8081-19a8fe434467"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, new Guid("13641715-b787-4322-8815-72a124fe9227"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, new Guid("ef4236d1-572f-4e7b-9203-c3a87c4b45d8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, new Guid("669a9790-49d1-45be-9505-a8400effe16d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, new Guid("9501c4b2-9cb5-400e-982a-391234164720"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2471), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, new Guid("3ec5df9d-ab52-41c4-b360-455a3b5cf2a6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2487), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, new Guid("6ee37135-8ff4-4a1b-acc9-6bb85d2dc22a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, new Guid("3c27fad8-7f44-4e39-a5c9-ee43f28cc41b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, new Guid("44276c0c-6632-4567-ab61-e225ece88792"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, new Guid("98d0f89b-e8fa-481f-a7f5-4706332cd1b1"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, new Guid("9aa425a3-5c25-42d1-a517-8dbf7a8183d4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2580), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, new Guid("fffd1156-d63d-4104-ae02-a12dc451ebdf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2593), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, new Guid("5793874c-f6d2-4ad4-a91c-2bd054b71f53"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, new Guid("33f6b52f-f7dc-4e9a-b64f-e99dcf9d2e3b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, new Guid("64637ce9-566a-4f12-bf39-14c32df54392"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, new Guid("bc71ffb0-3b44-4529-a068-e1bc91855dc2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, new Guid("03d9b243-2725-4e51-9874-f97893fa6299"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, new Guid("e031e0d7-c0ae-419a-884f-64064c817955"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2676), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, new Guid("6e107c06-8f4f-46b6-bfe0-2a7412ab2111"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, new Guid("4b828dba-7050-4022-be49-758a3021d008"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, new Guid("6465cb69-ce95-47e7-926e-dfc19eb4d646"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2741), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, new Guid("55a6c39c-ae84-495b-ac27-e2ec447a4371"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, new Guid("ae35928c-2506-4837-b93d-5cf8fc965f14"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2769), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, new Guid("6323dd40-4fba-4f08-8719-f87380802b49"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, new Guid("0abc4d8f-eac7-4c83-93c2-3f5ad70d0a13"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2796), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, new Guid("f2ab3abb-a01b-42e6-9e43-07c4fb5ca4f4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2811), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, new Guid("12b34eeb-8529-40ff-b2c9-51b411879f17"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2825), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, new Guid("ffe400ed-222e-4ee2-bdb6-27967f6b76ea"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, new Guid("2704847f-bde7-40be-8a96-336d16002133"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, new Guid("abc3678e-6d45-471a-a722-b94f14ee3f75"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, new Guid("e6c4a364-c53c-451d-b4d5-e1581a4a9d2f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2883), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, new Guid("1bd05392-c54a-44aa-9659-a3164c51fd7c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, new Guid("8c876423-9e93-429c-8855-dd67a5ae9c9a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, new Guid("b5075676-241d-4bd0-8749-5b677182bb8e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, new Guid("1e92dcfa-defe-488b-a310-8f985ae8e6ce"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, new Guid("b3bbff5d-6f1c-48a9-8493-4bcba7dedb87"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(2988), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, new Guid("44fabefe-3686-499d-bfe9-ec2d31dbcf02"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3001), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, new Guid("8b7f65a2-c5ed-4a51-85d3-c52aad0c9553"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, new Guid("6345eaae-7cf7-40a7-b89a-0fa42ccf33b0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, new Guid("02640fd8-4a4a-43c1-87f9-2100ceaf9c8b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, new Guid("432629a9-071b-44c3-a6db-e487b9369ce7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, new Guid("b1073082-3796-4716-98df-b11962779ecd"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3072), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, new Guid("b49dfddd-a38b-4dc5-bec6-d2e36c62d955"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3085), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, new Guid("f05977f1-a572-4ce2-b70d-a3477877bc91"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3128), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, new Guid("35780f66-8643-4412-ba78-1fc07e9c8808"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, new Guid("f9bd9547-cb0b-4de7-bab4-464c2bd2d6eb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, new Guid("b9469a05-8c8a-48f2-af72-517736b0ce85"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, new Guid("e7325dbc-0606-481e-8bff-35ae7bf86aba"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3184), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, new Guid("7b19a0fa-1014-4eb7-b159-bd07393b61f1"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, new Guid("382904a6-f49e-42ee-9bf6-b75df19987a2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, new Guid("d5915af6-4dfe-4be7-a2a4-8933243be5d6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, new Guid("f5ad926e-f6c7-4e0e-b6f5-5a0b674baf9f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3239), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, new Guid("071e0c0f-b3c3-4fa7-b5c9-84743d96f8ff"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, new Guid("c0654cf1-11ad-4036-b9d6-9f0e1eae2294"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, new Guid("98206caa-0246-4032-8155-6701e8079829"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, new Guid("86d02cbf-f0b3-4cc7-945e-84e8a14bdc34"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, new Guid("f7d1cff8-d05c-4a97-96da-122ae4bfeaa0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, new Guid("a8d6c68e-f26b-47b8-b4e8-4bbb22022cc7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3350), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, new Guid("b4730a91-3787-441b-bafd-3d2059e678d3"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, new Guid("222feff6-26c9-4a39-8b17-b4fb63c8243b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3376), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, new Guid("a948b7e8-2d89-43f6-be97-4dd6fdef5968"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3389), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, new Guid("5d5241a4-7b67-4d58-90c7-11bb051ecd29"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, new Guid("58ce1a47-07db-4b4d-9599-83218bfcbf28"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, new Guid("5611b437-f3e7-4a29-a140-cb5f53501ea5"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3431), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, new Guid("d87199ec-ab64-47b0-9244-3c913fc83f04"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, new Guid("9224820e-95e8-482f-880d-a91ad68d78a8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, new Guid("0153e5d4-5499-4ea0-8d93-8dae663b62ae"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3500), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, new Guid("1b5251fb-450b-407e-879d-e792c156f08e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, new Guid("c73dee35-acb7-45b6-acca-d49d4ef5024d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, new Guid("7629792a-d30b-4011-bc54-04b85930f71d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, new Guid("294bea4e-7578-49f5-9a50-6ff600301b04"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3601), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, new Guid("d3bb1c76-6323-41d3-bced-edb97d9c8ab7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3614), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, new Guid("b9f29d9e-8d59-4b2c-a942-fe24bf3551a9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, new Guid("883dfd95-c04d-4dba-879c-e8c5804da1c2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3642), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, new Guid("e050f4d8-643c-4d0d-8760-af400f4c7af7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3656), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, new Guid("bc05ad6f-6062-47a5-a531-bb06421bc4ee"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, new Guid("986792f4-d8b0-4535-91a1-d1f75e51185c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, new Guid("0f6fe23d-c05d-4ae5-a5b8-67b18b1c9424"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3697), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, new Guid("0f85d698-c2eb-4a14-909b-780ec40a5eab"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3711), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, new Guid("01900203-b42c-4534-bc71-2913fb1fb928"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, new Guid("92110aec-b90c-46c2-a0ae-809d1e8f639f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, new Guid("dc3c789a-4965-4ca8-a50a-8dd678dc5a47"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, new Guid("05dddd38-b03e-4699-98aa-2243cf633697"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, new Guid("b437b345-a5ed-42fd-a95a-9d8dc2068f35"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3812), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, new Guid("9eafcb7d-e296-4398-aabc-84f2d06dfd72"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3826), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, new Guid("68a2709e-a7b1-4edb-b208-54483568760d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, new Guid("3c7698a2-6077-4911-a893-8e8343ca0b92"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, new Guid("e8f56da8-9579-42ee-8cfa-67143145751d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3867), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, new Guid("f8a466ac-8bae-41be-94e9-6c3e7e7acb15"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3880), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, new Guid("e2333e6f-04d5-4b6a-97fe-6a61aa549deb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, new Guid("c10540d7-09f6-4eac-9dd7-e708c0c1aa4f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, new Guid("a17f2f53-3dab-4ead-bc87-92c4824b4a5e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, new Guid("fe8fb729-90eb-4d6f-8494-87681bade5bf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, new Guid("20d64126-770a-4141-954d-51017dbcde1c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3979), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, new Guid("4ca690be-e92b-47e0-88e5-709386b841d9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(3992), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, new Guid("77c0a2d4-285f-4b0d-8182-daae78a20b50"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4005), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, new Guid("38858721-939e-4a2d-95ec-48499288b0fb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4018), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, new Guid("9acaa04f-c778-465f-b117-3cc234cee5e5"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4034), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, new Guid("a71be72e-7b7d-4d74-86c1-cffc1377c642"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4047), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, new Guid("ab5e3c71-ea3e-4830-a317-e0f08141f36a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, new Guid("f6e3d116-8379-4194-83f7-3919e0feb49c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, new Guid("0523400e-25fb-42d6-98f5-999c212b187d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4089), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, new Guid("f7603a57-210f-455a-bdb2-08ff09103829"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, new Guid("0de39c90-8c5f-4e0b-895f-bd0476249382"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, new Guid("dc07f755-a812-40d5-8563-f027e3acc631"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, new Guid("82b292c2-6727-4c55-a44a-5c4e19f715e9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, new Guid("9d8c2d08-8a52-4bc5-9f3e-7c864a63eae9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, new Guid("8f54cc7a-202a-413f-8b43-c4ee1898889f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, new Guid("7c382ecc-14fa-4395-8413-393fcf25aa1c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4216), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, new Guid("e43091f8-8b3d-4c9b-b1a8-040497bcb7a9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4231), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, new Guid("f32daa91-4851-450c-bd25-59b3b60c778e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, new Guid("34789eb4-b1b3-42cd-915c-b6462ceec469"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, new Guid("1fc0022e-3f1a-44c2-8b2b-56ba173d3b2b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, new Guid("91602b20-1d98-433a-b38a-0e0451a91a0e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, new Guid("19f69849-ea91-4bbb-bd8e-6aa515c7b0d4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, new Guid("99b71646-1203-4232-86c8-2b9609805bdb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4312), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, new Guid("c7478898-5834-4341-9b21-ec38bfd4956d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4325), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, new Guid("a9c5d7b5-1609-4456-bc70-df7257c027bd"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, new Guid("6cfbfc69-13d1-4376-b809-bf21b51cfeef"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, new Guid("3611ad1f-2423-4d0a-bad7-1772af9ed88e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4395), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, new Guid("77373a52-ef52-4bae-ac74-936021850462"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, new Guid("16f8d2cb-f115-462f-ab3f-919645bcad05"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, new Guid("507fa1b1-7802-40df-9206-2f868af34801"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, new Guid("ccd7265e-21f4-4f04-9152-8050bc9d36ac"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, new Guid("2f79f069-50d4-4ed7-b43f-ac520f2e590a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, new Guid("e32a1044-989b-44d1-99dc-63e23bbefbf0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4479), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("4065b8f9-1ccd-4225-963c-0ad8ed635b8a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(49), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(50), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("a64b6c58-7aed-406a-8eb2-022a43fbf3fb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(64), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("a1895fee-e790-40c1-b83b-24103d080c89"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(76), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4723), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4732), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4741), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4750), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4759), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4769), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4779), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4791), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4804), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4814), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4823), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4862), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4875), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4886), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4896), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4907), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4917), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4927), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4936), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4946), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4955), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4965), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4975), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4985), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5004), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5014), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5024), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5043), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5053), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5097), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5107), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5126), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5136), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5175), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5185), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5194), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5204), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5214), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5224), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5245), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5254), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5264), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5310), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5331), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5340), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5350), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5360), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5370), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5379), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5399), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5408), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5418), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5428), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5438), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5457), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5467), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5496), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5506), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5515), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5564), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5584), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5593), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5613), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5623), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5643), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5652), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5662), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5681), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5691), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5701), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5710), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5720), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5759), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5806), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5826), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5836), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5865), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5875), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5885), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5914), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5924), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(5991), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6001), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6012), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6031), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6051), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6070), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6080), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6099), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6109), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6119), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6129), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6138), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6148), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6177), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6187), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6196), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6230), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6241), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6270), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6319), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6348), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6358), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6368), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6378), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6387), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6397), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6407), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6416), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6426), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6436), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6478), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6500), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6520), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6530), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6539), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6558), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6568), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6578), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6587), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6597), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6607), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6616), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6626), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6635), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6645), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6673), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6683), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6726), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6736), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6745), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6755), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6775), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6784), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6794), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6804), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6813), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6823), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6842), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6852), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6862), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6872), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6881), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6891), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6901), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6920), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6952), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6963), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(6992), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7002), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7013), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7035), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7054), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7063), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7073), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7083), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7093), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7102), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7112), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7121), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7131), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7141), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7151), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7161), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7206), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7217), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7227), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7237), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7246), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7256), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7265), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7275), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7285), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7294), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7304), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7314), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7323), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7343), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7352), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7391), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7401), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7429), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7448), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7458), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7467), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7476), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7486), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7496), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7505), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7515), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7524), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7534), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7543), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7578), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7589), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7608), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7618), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7627), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7637), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7646), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7656), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7665), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7674), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7684), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7694), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7703), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7713), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7722), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7732), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7741), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7750), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7769), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7779), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7814), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7836), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7845), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7855), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7865), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7874), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7883), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7893), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7902), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7921), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7931), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7940), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7949), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7959), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7968), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7977), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7987), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(7996), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8005), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8015), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8059), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8078), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8088), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8107), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8117), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8126), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8136), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8155), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8164), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8174), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8183), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8193), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8202), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8221), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8230), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8240), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8249), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8318), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8333), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8343), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8352), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8362), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8381), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8391), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8400), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8410), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8429), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8439), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8449), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8458), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8468), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8477), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8487), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8496), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8515), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8525), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8534), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8571), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8581), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8600), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8609), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8619), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8629), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8648), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8658), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8667), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8677), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8686), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8696), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8725), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8734), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8744), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8753), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8763), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8772), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8818), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8828), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8848), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8857), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8867), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8877), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8886), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8896), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8915), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8934), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8944), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8954), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8973), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8982), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8982), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(8992), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9002), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9012), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9021), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9055), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9065), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9075), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9084), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9114), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9123), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9133), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9142), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9152), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9171), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9190), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9209), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(1), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(2), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(6), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(6), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(8), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(8), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(9), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(10), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(84), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(85), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(88), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(89), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(90), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(91), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9464), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9492), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9303), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("a0afc7ee-fb9b-46b4-b96c-2385a853af2f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(956), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("103208ab-84c3-4b02-a0b5-de037eba48aa"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("e882b87b-3e55-4b70-bb0f-cf88a4c4c0ff"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("b79a5bb6-3f8a-4457-bb4a-87352373f5dc"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1004), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("a14a489b-a236-47ca-88ae-32ca9b88b2c8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("1055fc97-12ef-4bc7-ac90-1aca639ed379"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("1ab14a29-6038-4870-8979-ba5dd0dfd747"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("0d15b512-e0d0-4b83-a208-6b3555274efd"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("0f950495-ab0f-4d3a-af31-111a01a8874c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(1098), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("1b23999a-c8cc-4d15-9fff-68c81a48931c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(301), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("9a507c9a-9381-4219-b3b1-47d4bbfe3799"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(312), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("7ee5648c-32c3-45e3-8c57-40fc9e40221f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(315), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("c5e575ca-b925-4cd7-84e3-01fe50bff7d8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(318), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("62e9ab75-cc28-486d-8e65-b2229a429587"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(321), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("bdb89b04-46bc-4c4f-b84c-cc6f44a15396"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(369), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("48462456-49f8-4e6f-b9bf-f332dbe43942"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("1b866efa-21ab-4f00-a488-dea320a6811b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("2dc11c96-b313-4ced-b85e-28ee1b0e3d15"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("da87965b-6834-4531-992b-b732ee55c1b4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(381), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("7e6d914c-3f3e-4224-a421-7594f60d469c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("a1015754-701d-495c-a825-39105d2661c6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("a44cb71d-c8d2-4fde-a291-c5a5bed0fd3d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(390), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("7987efbc-1424-453e-8559-5e287ee3f4ba"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("2350a656-c80f-4504-aa92-89f2f93e83af"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("fdb2b325-98c2-448a-b089-3f513a9c4c3f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("a4ccd24e-fd07-45c3-9d4d-4370e7042ce7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(404), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("9775c5f7-b7bf-417c-8218-59b5653f30a3"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("4c699365-969d-4215-8c69-cda61b79c297"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("103270a7-f855-4dfd-a697-eb29dae94ed3"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(413), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("a57cdfc4-043a-4a05-810c-b5fcc4b9785b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(416), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("a827b2e3-9c98-445f-83da-f6b7847d5f3a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(421), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("245f98e9-32dd-4dc7-a672-dcd0b0120d54"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(424), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("e5636bec-4b69-455c-b776-d6ff29e906a4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(427), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("410fa020-6ed3-45aa-b3cb-7b2ad3667d7d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(430), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("3750848d-57f4-4cf9-8bcb-16ee983882c8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(433), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("6e4685a8-1dd1-42dc-b972-d59896c28062"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(436), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("d4cbb9ec-7c74-4917-8d88-bd1b9003d0b1"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(439), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("5655007b-4a2f-4e09-aee8-3ab8a6808400"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(442), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("0bd3dc6d-a1f5-4d93-9b5c-ed80e8bdf4ad"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("2df50834-944e-4b3f-891d-e4aea4e76fe7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(450), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("14cecc9d-0db9-4342-8167-a31d75163e27"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(453), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("a6d94d9b-1ee6-459f-8a2e-bb16ee6050a3"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(456), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("ec17d30d-d1a2-4659-aaba-2a44f0757a36"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(459), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("2877720b-901d-4438-a45d-12b07596cb18"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(462), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("4939117c-ea0a-4e7b-93fc-c7e1045976a9"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(491), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("79688d2d-690d-4871-bdf0-6baec953f325"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("7d42f2e6-77f7-411c-b139-b8f7d97427b5"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(499), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("e9af1e50-a41f-4284-b668-0c183b5cb060"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(502), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("29d49b3b-18bd-4b2c-805f-647d343797b2"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(505), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("ea8a809f-006d-4c45-85f3-4d69f97b3a2a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(508), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("098cb112-3e9b-4d89-98e0-ec19b45902a0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(511), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("7cfc36da-0277-4f15-ad9a-16f8c85279d4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(514), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("475044ec-3bae-499d-aa3c-d01a0d4b46bf"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("7054e7f9-aea6-4b09-9cc2-7c467a9ba580"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(520), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("488c3207-396e-43f4-b759-8b5c3b141003"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(524), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("42f608b6-ec9e-4cc5-a068-9716044aa521"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(527), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("4fca3e93-ff19-4e30-856b-be945f9c34f8"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("c87fa3a7-2a89-4410-941c-03d0b7a8dbe7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(533), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("886ebec6-b4b5-4689-be29-3a9d95629e29"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("570af7f5-c97c-45c0-9a25-30e1c89d48e7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(539), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("8b68f9c6-e5bc-4108-b1ab-17d1c4321c01"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("41fc3028-a1ea-4a31-a9d0-9246345df32d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(545), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("666be505-867c-4ccf-beb6-7c4f97ccdfd0"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("c5f485e5-ccb8-4ebc-9e96-8b7f5c4a6488"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(553), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("604af691-1cca-45d9-83a6-046386e17cd4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(556), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("0d2b1cce-de09-4896-9d19-312eaf5f025c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(559), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("a0985ae4-0ec2-4dd0-90e5-097881f2e828"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("48a9cf0d-b0dd-445e-81b0-08c399ea7e64"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(565), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("1ca7bdcd-3822-4feb-958c-cad6d2bc079a"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("7e015620-9d2c-4e37-9a59-c1fe109204e6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("03802754-1e98-4728-b7bb-030428f35058"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(576), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("bbc26875-35b0-4844-a1cb-a602a135a454"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(579), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("85e8c18a-b0c6-4022-bca8-822f22a44202"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(582), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("c30f16dd-f929-4caa-9a07-b9c88af77b97"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(612), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("6ea7cc66-38fe-4bb9-8ba6-fc899b08675d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("348cd24f-76ba-4982-954d-0a4c7c8ae87d"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(619), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("a9de4de6-b3e4-49ba-b50f-70b5d718f983"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(622), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("7eeb6d2b-a66e-44d5-a829-55692b0c00ae"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(625), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("4a00b88c-f996-49cd-a1ae-ea9e6db41306"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(630), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("1e41541d-9321-4fef-bf79-717f91a9d873"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(633), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("0b7ca83a-a704-4ff8-9c5f-41bb770f253c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(636), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("e17dcfe0-5874-4094-99d4-8f4ec1a3134f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(639), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("8c20d4c5-4dcc-4bef-b0ce-0529c7845730"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(642), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("b695f169-5ffb-49be-8904-99245aa696a5"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(645), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("f17f00cf-4b7c-419b-a341-64f6c27e75a4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(648), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("84b3abaf-b598-450a-a3e0-e5f1f8709505"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(651), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("922172f1-c109-4213-9975-a39213a25d96"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(656), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("a26a81a8-0d05-46d5-95e9-6254c50dd248"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(659), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("a9e8e04a-0253-4b1a-8e0d-d1e352ac87d6"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(662), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("b01506f3-4378-411d-8b7b-2963ae512957"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(665), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("e3112183-481d-4dd8-9426-a0c86dcb5baa"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(667), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(668), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("24760b9e-0b5a-4bc5-b615-04fd5f39e59c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(671), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("df129ec3-5238-4ee5-8d60-844837c6d933"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(674), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("6c4e6541-71e4-426e-91bf-083babd8abb7"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(677), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("f75ec7b0-230b-407a-a10c-640887e2e63b"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("98b20112-a26c-42bc-906c-d70c218925d5"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(685), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("891dc28f-9bcb-42a1-89c5-ecbaa4cea1a4"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(688), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("4e40fb6a-9778-41b0-bc7d-0f0400d57e74"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(691), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("11fbc398-29fd-473a-ba49-91e376369438"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(694), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("89e56938-ed34-4f43-a9c8-20f5a04e8e67"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(697), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("6608bca7-7ebb-4b02-b0f1-d4a748acf9c3"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(700), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("d817fca5-cf22-498d-a310-1525f10f07eb"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(703), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("377a516f-3cbc-4780-b9eb-6c260c8cb214"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(707), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("cfc127be-2897-4066-acf9-1fe6f398d0bc"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(710), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("19bb8c6a-348c-46ab-be46-7d9d17b4ae16"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(713), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("ba753676-ad63-460d-9e30-a131b3946012"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(717), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("a9d1da51-4ee0-4523-a2da-249d954ebd1e"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(720), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("cfd4a8d9-6e4f-462f-9b8a-fda4d12e46fc"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(744), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("d80ce4ca-c903-4ccb-a68c-1e45d2b7360c"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4498), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4512), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4522), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4541), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4552), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4601), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4615), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4625), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4636), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4645), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4654), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4665), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4674), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4683), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4693), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(166), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(204), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(230), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(261), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9320), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9436), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9543), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9596), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9617), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 749, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("d6688df2-f801-4c88-ad70-e54eb6dbdf37"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("4be70abb-5015-4932-a6de-21c4e0e36e12"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(294), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("41f49b6d-0758-459b-bad4-b435d029e328"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(297), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("8a0a6e45-8e71-4bd3-9ebb-af6f49d0af2f"), new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(299), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(829), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(831), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(833), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(834), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(837), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(839), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 5, 14, 58, 31, 750, DateTimeKind.Unspecified).AddTicks(841), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
