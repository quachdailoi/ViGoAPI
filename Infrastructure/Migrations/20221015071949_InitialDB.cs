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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("aa7deff3-e331-46f1-aea9-96f18a3de681")),
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
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
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
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("1fe130f4-443a-4e32-ba95-b4229dc9ade9")),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    option = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    is_shared = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    start_station_code = table.Column<Guid>(type: "uuid", nullable: false),
                    end_station_code = table.Column<Guid>(type: "uuid", nullable: false),
                    duration = table.Column<double>(type: "double precision", nullable: false),
                    distance = table.Column<double>(type: "double precision", nullable: false),
                    start_at = table.Column<DateOnly>(type: "date", nullable: false),
                    end_at = table.Column<DateOnly>(type: "date", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    promotion_id = table.Column<int>(type: "integer", nullable: true),
                    route_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_bookings_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 302, DateTimeKind.Unspecified).AddTicks(8119), new TimeSpan(0, 7, 0, 0, 0))),
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
                name: "booking_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rating = table.Column<double>(type: "double precision", nullable: false),
                    feedback = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
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
                    UserId = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_affiliate_accounts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id");
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
                name: "booking_detail_drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
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
                    { 1, new Guid("2f2df2dd-585f-4904-8027-fe92628be815"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3086), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("26429afd-eefd-40af-9012-b62e8b21a220"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0c627d9c-caf7-49e2-aff5-740d7f77bbc8"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3146), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("2f133567-6404-41f3-aee3-e1754e702515"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1089), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("89c63f4c-1448-4166-90b1-91cc6495211d"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1108), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("7f212e4f-17f5-4fec-8167-81b9bbe2e8d2"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("5cb6d21d-82a8-4537-babb-4896abe141ba"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("593ee608-70bc-45f7-9762-14e99b40bc94"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1139), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("62cdbbaf-0523-4d2d-a6d6-cabfb8662c4b"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("c8a82289-4a39-4881-881b-667dc317e997"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1172), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("e6b923b6-5c8b-460e-bc88-9361f2e7005f"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1183), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("373483d8-f2b8-44d0-9cdc-c2149f74776e"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1193), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("6259826c-e6c3-4b82-b3bb-3fc66121d6e1"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1204), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("d58f2390-9c51-4c6a-bab5-b4fbb8469b09"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("a47c4274-05b9-4455-9260-95b10825d18f"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1225), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("a86ff44d-4157-4ad4-9bd4-48fad591a963"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1235), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1826), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1894), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("3fa2b1d7-68f0-4b67-8e90-ba389ac245a2"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("341813cd-8ddd-44f2-84be-4039708226cd"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4713bcd4-9d08-415e-aa34-fbdd23859a76"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("12cac30c-671e-49ce-a58a-811b7a337854"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("06185943-e21e-46c2-b0e9-9cb2e533c790"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ff7c6925-6e8f-41a2-8be2-0dec025d831b"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fc6776be-6185-4295-95cc-9832ea81ca63"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dcaad4a0-4cb5-4b18-b011-e9843356b7e7"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("2948eb03-b958-4cd4-a5d5-db88baeef490"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("7e0ce65a-a8c9-47bd-af50-d98c3cafea93"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7bae3cbf-f94b-433d-9fd0-627c8a18c61b"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2286), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8fa18d4b-405f-4647-b1c7-40f662295f4c"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dd1909d5-3bf8-4c19-9956-32bd38187f4f"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2342), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("4aed5b8a-5535-430b-9b4b-f4b9180b8fab"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("59864375-f985-456c-9c4f-be6b739525ec"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c07c160-2333-486f-91bf-991302f97be3"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("612295aa-4d9c-4b04-bd6b-4e912a4c7936"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2354), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("76d29c1b-5978-45f8-862d-321328d36ce1"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4b230a90-6910-4dba-a2d0-d693671dd073"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2cc5eacd-81c8-432e-a4a6-2e13620398b2"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2366), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d27775d0-d422-41f1-9bb3-d251ca71dc9d"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2369), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("49f7792a-3a49-439e-b502-dd8934502b0f"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9e42344b-9aa0-434a-8144-4188fa73f7a1"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2379), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7d88f264-3744-4f6b-ba07-403b84e7e795"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e84fc604-13e2-4383-962e-219b14361e12"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("43c29feb-a08c-402c-8f58-b0692a76b87b"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2390), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b23611f-c6ee-42db-8a5f-a5a2747247a0"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("38ffddf2-d336-4629-8234-0721200b5dc8"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("104978f4-cf5b-4e68-a457-5774094bb6cd"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f62d8f96-985f-40c6-8fa2-83eaee633516"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c2414697-69dc-4feb-9ab6-0a89c41744c0"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7e8e4cea-8029-461f-9754-83106b4ee446"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("846ef264-586e-4db4-9583-bc7d350fe1d5"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0a903bf0-5d52-4d48-807f-f58f68caccc7"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2419), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a0c3875c-34bc-4414-89ad-ef4f8eba946f"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("20de1529-8dd8-48f6-98f1-cab2bee77d8d"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("f1f0c468-afb8-4770-ae7b-2ad7f3ac0b30"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("177ebb11-20a3-4472-8633-0e95305deb8c"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7e652c7-3194-4e8d-a81f-695dea7f8dc6"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2434), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0eb1a10-44b9-49ad-a4b7-0579a26893b8"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b8556f49-52ae-4f27-9a61-eb8bd08e3f5b"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c9ce7cef-9a6f-42a4-bec4-dc5fce9b981c"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("01a1da56-24d0-43ff-b105-6903c9799310"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("0843097f-efdc-4818-97b5-6a3dc7c3a758"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cee90a01-3c32-4340-99a8-b08b1062484c"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d2c7c404-b588-4d9d-beb4-f35a803e3e79"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a9a6fab8-ecc8-4dd4-92d7-4ef9e0490261"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2461), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("11898603-a6b2-4b34-8654-026a1be547d2"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2464), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d1076b3-4f49-4908-b487-7d7d98382933"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("62442daf-ac63-4e85-a180-965bf2f393da"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2472), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5761787b-1da7-4697-8b76-4826bbc5ed28"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2475), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b13a88bb-f3f1-4f7c-83e8-68dea5e81135"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1e972066-868f-4c09-8db5-c8d3bbc077fd"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2574), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2f11773e-935e-4ba0-93ef-f175ec9b91c8"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2159a82b-5864-404b-9f0e-9b47e6a92bdf"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2580), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("433f1344-812e-465d-8432-d21eded03f3b"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2582), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("78e439a7-0aa0-45fe-b768-0081a3cf378c"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("18d87acd-6d88-4c0a-a285-a39665d39442"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2594), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("94b569a9-8304-48c6-bdd4-d0e74bd981ee"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2597), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb17670c-f370-4e76-ad1a-b3d6e38f27d0"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a2601579-93d7-4162-8d6a-276502113f7a"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2602), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b282b7df-0836-4178-922d-ffec39612595"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("195cd848-14ff-4eb5-879c-aeef253a7962"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2608), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ccd8861-ca83-4b5e-a0d1-94a603d9e7ec"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("559ba265-4d14-473d-89e3-a6f5e2eac066"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2617), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aad8ddde-a972-4d9d-a3c1-fe16e763ee11"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("61c5cfc7-51c1-4414-baa7-1c5e00d0fa81"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2623), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4aa97b83-5f31-4e15-9f5b-420f45b01c4f"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("30ee5044-a330-4a75-bea0-e66c9a4f58da"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c1ef4671-b5d0-45e4-9139-6bd28883a829"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("05828a0a-88c3-4373-a539-1d1387bb6311"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("054c224a-f193-4041-ac0f-41d324e25603"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("89702e1f-312e-4e2d-91f5-d9bbb9725c2c"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2644), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6377abee-bf4d-46d8-85e3-83f3813078ee"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2c0cd56b-d256-4f7d-be2a-b1bf98dd0120"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2650), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ba42686-6bd4-4c6c-974f-df08ed914f62"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2653), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0104328b-9280-476e-bcd6-6ee9701a911c"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("519aa307-c19b-4d1f-b0db-d921cb5fe7fe"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2658), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d19e79ba-b998-433f-9f81-6f8e3f2953f1"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("357373b2-847e-42af-ae6f-5c000d8c8b93"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e7a55ce4-9fc6-46e0-be2c-06822de13ae3"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("bb6bc318-19c6-498a-aad5-fd80f8a82a5c"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("7bb0f2d1-7bfc-4c3a-9b56-edba52627121"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("68475c06-b27a-4fdf-9206-595417245816"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("020b2fcb-e5bb-4031-8fb8-bc0fe96964a5"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2376), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("baf24240-e10a-4f2b-884a-564916668d2b"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1443), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("3caa76cd-3839-4eb7-a2e5-48f6d1944f85"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("25c0bcb9-28d2-4cc6-b502-cf2ea33d81a4"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("45c6be22-5b2e-4961-9712-e15fbb9f0f37"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2811), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("db87e6c0-efc5-4f58-b51b-f486ad80f3e9"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("a3d9f2aa-99c2-4a39-ace5-e8675a7becae"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2846), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1736), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1745), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1755), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1764), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1773), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1782), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2766), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2768), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2770), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2855), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2859), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2069), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2092), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2115), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1799), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1904), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("f0a8300c-ee87-461d-ac2d-61f09eb919f1"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("96cd7eef-3df5-411a-9481-28c494219813"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("a7bcbcdc-77b7-4f95-9948-5b19c4aabea2"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1344), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("b2f591b5-fd4e-4a61-9f1b-91da2b7c3850"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("971c5089-6e0e-4bd1-80f8-2fe0203f84c8"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("b3c3b609-01c3-45d2-9fdc-5b979d51402d"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1389), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("a90eb56f-0eb5-4d56-a274-6f655739b755"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("68cd519d-45fe-41e5-ba1c-23412d18ac29"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1415), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("88b644cb-d28b-402e-86a2-1e7cda4f4de6"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1427), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1485), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1539), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1595), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1609), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1618), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1628), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1637), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1658), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1667), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1667), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1677), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1687), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1696), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1706), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1716), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1727), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2934), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2992), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3000), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3008), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(1921), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2042), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2167), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2190), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(2224), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("1e15ae11-a0c8-44fe-88ee-bcfa36383cc2"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("fa0e1a7e-5b0e-4532-8e82-321279e3a0eb"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("837d24cc-f77e-4814-af25-586567d0cbc0"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("3d81faf3-18df-4984-b64c-58e15d392bf8"), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3175), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3177), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3181), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3184), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3186), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0, new DateTimeOffset(new DateTime(2022, 10, 15, 14, 19, 48, 310, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
                name: "IX_affiliate_accounts_UserId",
                table: "affiliate_accounts",
                column: "UserId");

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
                column: "message_room_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_code",
                table: "bookings",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_promotion_id",
                table: "bookings",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_route_id",
                table: "bookings",
                column: "route_id");

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
                name: "IX_route_stations_route_id",
                table: "route_stations",
                column: "route_id");

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
                name: "promotion_users");

            migrationBuilder.DropTable(
                name: "route_routines");

            migrationBuilder.DropTable(
                name: "route_stations");

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
                name: "promotion_conditions");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "wallets");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehicle_types");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
