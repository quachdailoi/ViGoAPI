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
                name: "affiliate_party_types",
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
                    table.PrimaryKey("PK_affiliate_party_types", x => x.id);
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("6aeed996-62f4-4ca7-8cb6-e0764398bd39")),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("8ab04685-ca7c-4888-9052-ca006f9b404d")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 660, DateTimeKind.Unspecified).AddTicks(9842), new TimeSpan(0, 7, 0, 0, 0))),
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
                        name: "FK_affiliate_accounts_affiliate_party_types_affiliate_party_ty~",
                        column: x => x.affiliate_party_type_id,
                        principalTable: "affiliate_party_types",
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
                table: "affiliate_party_types",
                columns: new[] { "id", "code", "CreatedAt", "CreatedBy", "DeletedAt", "name", "status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("80354b82-ac0d-49ef-b2ac-9270021a6fe4"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6900), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("323c30ce-d4ee-4472-b2f8-72b23ace3095"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6904), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("24c1be37-d94c-4859-b4dd-374f20adb3ef"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("e9f2ef96-67f4-4c77-95cc-7cc9707298d8"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(4941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(4965), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("6929f194-4bde-4f4b-8f3a-09b3be150098"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(4982), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(4982), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("6d8345e4-1955-4e46-b3d8-f561cd3063f2"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(4992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(4992), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("612c82bf-4b76-49ae-a751-804ce05a25c5"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5015), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("e52d7453-cbe9-413b-af46-bfb64fc35bd4"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("03d722b5-559b-4027-ba3e-f395224ab8cc"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("4b0e4955-c724-425a-a634-9212d50490fd"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5046), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("f99dd086-3c17-4558-a8f2-de836a3848cd"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5055), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("9b7bc1fe-94ce-4645-8eb9-7fcf1e336206"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("348cdcab-015f-4996-bd3f-b4d51e8b7fc0"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5075), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("00081036-e5a5-4fc6-9346-3a30c451a3e5"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5084), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("38362dca-686e-4293-9afb-699be0452fc9"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("4c04b56f-bf7c-4bac-a9b4-584d44a7ca0d"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5108), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5735), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5746), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("719dc843-df64-40a7-890a-7895ecb7a213"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fd117877-dfe6-4a55-9990-ad718a052e1d"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f2ce6167-4bb7-4922-b4bc-cb06094f1641"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6103), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ae67db97-1694-4dec-998b-cdb257c1e066"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f3d10bc6-aeed-465b-bd1d-532bf2fc3a62"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6109), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e41efd72-f0d8-4c38-8bea-9c89beeac966"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a3b9f28-776e-4e27-87e4-491f848766cb"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4499c7c9-3b21-48ea-832a-4d80c218a23c"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6123), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("ebdc5994-ea8d-402a-84c1-bcf432f960b8"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6126), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("52e3e3ed-9a9d-459d-8506-51fa17d83d2d"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("57547b8d-6f04-4888-b96c-5ea0d451baad"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6132), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("512a7d12-087b-4895-aef5-a64498e14f04"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6135), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c440deb-2ca8-445d-bf67-686a7eae281a"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("8563d10a-21ca-4b7f-9b19-7e642a1be5c9"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("be53522e-c7a1-4856-983d-fd4560d7706e"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ecac3319-907f-4998-907e-dca21553d6ad"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df097031-d4ce-4adf-be44-528ade0a9083"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8a2c77d4-572e-495a-a36c-fe1923113b03"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6204), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0a5e55aa-9acf-499e-9483-43197e05d81a"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ef453dd0-ea21-4517-9792-f3ec6502c925"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6209), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e7658e4e-a0ce-45e0-bfce-c5bc839748cf"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6212), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c5821374-42b2-49d6-9b7f-6e52e34b03c2"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1c91c452-15e3-41a8-8794-4026d4652195"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e12e717b-d355-4641-b855-6f5f1717547d"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3bf08324-e138-4296-bab0-d9da3b1c9fac"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6229), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6b4c499-bb1f-4a86-a19b-cd76539df115"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8720bce9-d3b8-47f1-8a2f-3a76afc2eaf3"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6234), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5f6fadb1-c340-45fc-bae9-e587a654c0bf"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c578cc8e-7eb0-4d37-a131-a97241bafd90"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("05bd4d5a-8515-4609-8212-fba77ce2a0a7"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4e7853e4-c0ba-4689-91d5-9c42e694e368"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6248), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("075b2341-83b0-4235-9eb6-fd81d392e1b9"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6251), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("16c4a49e-57d8-4401-92e3-71e92bc21adc"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6254), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2a41ee9a-0043-4631-ad39-fb0bf2365f09"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3f528394-cecc-4fa8-8bb9-b4fc46fe4df2"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("47358133-2732-4617-95d6-4502f08fa5a8"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("e39e5d28-78a7-4443-97c7-429ca65065e9"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6265), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("804d8e91-7796-4486-9dc0-cb74ca1d291b"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6270), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("445863d7-8eda-460f-917e-c69279546439"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0c1e8f0-9453-496a-a042-abe8add244d7"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6276), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e453027d-efcc-41dc-9d67-3674011759e2"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6278), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2865c54e-275c-48e3-96f3-1d1319804e84"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6282), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("97ff4ee9-d75f-49fc-bd9a-2fd612e7e3fc"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("b33063af-309b-4d21-bbde-ee70f2b58f95"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6287), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1e8f1970-0611-4f1c-baba-5bfecc7af91a"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("332f245d-3795-48ba-9ec4-d81ba4ccb734"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f9653224-b614-4ebc-984c-abfadb0d4ab7"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8ae923f2-53b9-4c37-b33d-94b9b9242f2e"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("00a5bd92-3daf-4e30-a1ee-a669b11324f0"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6304), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1184175-c44f-4da0-9090-86f1abee5f4c"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a5654c4d-b4f0-4eab-924d-fa6971ad3591"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("709f3d65-6976-4656-9a65-6252dc009cfd"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6312), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("53dbb531-b648-4ff0-a767-3946bd81f43e"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d7626fcc-ca1f-4c2d-adaf-82047939897e"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ed965f8a-5ffe-4933-9674-78e52fc57f9b"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1ab7a329-3f41-44c9-95e3-8371533b5da4"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0c0edd23-5846-474b-a893-b0296fab465b"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6375), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4f2f3cd9-3143-474b-ac4a-05643bb6a776"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bea5b134-9c78-4d87-a8d8-c5423b716f89"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2933c59d-405d-40be-9764-b0c28ea9b25f"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3309730d-18c8-4c52-9cc7-e840ab7acad8"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eb1d4b57-836b-4a62-83c9-25c5bf9066a1"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6391), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c261d4b-ef9a-4053-af39-c8359e4eb2a0"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1eb91ac8-4710-4654-8c81-31770dc63b99"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb7892c1-1b09-4e82-bd30-e6b8877c6149"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6400), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("101b4880-45ef-42ab-9b15-c2201a33d4eb"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6403), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4c8b56a6-bcf3-4316-9b1e-f4d1ff5b6cd5"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6405), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7ee7dab1-f841-47b1-b321-b5d17bec7ebb"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6409), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b80f45a3-1ce6-438e-bab0-7eae8809da0c"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cc6b1bf8-2bf2-4e18-bfc4-70621d49da2a"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("4a36d453-4213-470d-b2ff-78a3891cbc18"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b2e382cc-86cb-4895-bcb6-de3b45df0d28"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3cf47e8e-8764-4657-af36-7cc40ec2b9df"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6b0a778-0024-485b-bdcb-53440b44d930"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df3127b0-21fd-4026-a9ef-cea6f4018e3b"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3b5d1f91-7d2f-40f5-a520-7a8bc0694acf"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6434), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("26468a9f-debe-4102-b263-b1420acb2669"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("66c49fd0-3c7b-42f4-b1cd-86f66bb3c701"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9138ab2d-4c36-44c4-ab3e-c793d924b493"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("14dc41b7-371a-420b-a80b-aae259a5b838"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("f2868c92-97b7-4f9a-9bfb-5b4b1aa4ab78"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("3c7ef9ba-21ff-4e75-b811-a7b8642ce2a1"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6453), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("6ad631b7-a5d2-49ba-a76e-70fe363f6807"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("c15babd7-9939-4bf1-8c4a-d64870950c23"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e5e96a9c-803f-4c96-9b1a-9a5329322dc4"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6221), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("083e1ece-4669-4a5e-97dc-2a2c90c99e21"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("a1caa021-95ed-4707-b567-ba24f7506aa3"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("342d7372-653e-440d-83bb-07fc6d528e55"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5333), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("523efc71-db51-464f-b60d-ab858bd27c88"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("1b7ef97b-bff3-4791-adcd-974d3276a975"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6638), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("fd733010-af01-4c9b-8321-76c9deed7797"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6650), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5593), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5611), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5638), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6659), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6666), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5944), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("a87e985b-f950-4eae-a1e1-e641e8b2ef5c"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5132), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("cbbc8244-da8d-42d1-84e0-29841bac3285"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("9cd50222-ac39-4a39-8008-eacab92f6128"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("8d476828-db6c-4bc2-816e-0c4cb7bc7f73"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("de6e4537-6ab5-4294-9f70-8bfc8c2ed235"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("237ce480-6ad4-437d-b5c0-947f55d22877"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5256), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("dbc40940-cf92-4c67-bb19-c75aed805f69"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("d403d7bd-a5e5-4c2d-b4cc-3a14668a7396"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("95a2965b-7026-46f4-b290-67baa706bc4a"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5350), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5362), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5405), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5415), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5474), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5485), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5493), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5502), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5511), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5520), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5537), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5545), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5562), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5585), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6738), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6748), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6764), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6773), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6781), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6797), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6805), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6813), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6829), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5897), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(5990), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6016), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6039), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6057), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6073), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("c01241fb-4945-410d-8a21-5789717e6813"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6857), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("672a89dd-e457-4117-8246-0fa99df54973"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6864), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("efce97dd-90d5-4d5b-ac64-3b72e0055979"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6867), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("a75c159d-2aa2-4f25-8ee1-e97dcd46e889"), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 36, 15, 668, DateTimeKind.Unspecified).AddTicks(6872), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
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
                name: "IX_affiliate_party_types_code",
                table: "affiliate_party_types",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_party_types_id",
                table: "affiliate_party_types",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_party_types_name",
                table: "affiliate_party_types",
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
                name: "affiliate_party_types");

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
