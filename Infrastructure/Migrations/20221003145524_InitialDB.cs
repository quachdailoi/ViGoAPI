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
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f3ffc3dd-74a3-43d9-b841-32f50becde0e")),
========
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("36e1a3c5-9997-4e00-a39a-acaa8dbf7fff")),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("5324c07d-e87e-47a5-9f53-313cbb0cf196")),
========
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("7581f2f5-f7c4-4e9b-9e25-de5596f5278c")),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 661, DateTimeKind.Unspecified).AddTicks(3231), new TimeSpan(0, 7, 0, 0, 0))),
========
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 448, DateTimeKind.Unspecified).AddTicks(4712), new TimeSpan(0, 7, 0, 0, 0))),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
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
                name: "fare_timelines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    fare_id = table.Column<int>(type: "integer", nullable: false),
                    extra_fee_per_km = table.Column<double>(type: "double precision", nullable: false),
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
                    driver_id = table.Column<int>(type: "integer", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_booking_details_users_driver_id",
                        column: x => x.driver_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "booking_detail_drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
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
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, new Guid("e3adc677-45ea-4353-9586-3fad3585e4c6"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("56d4bd35-7ca8-4b63-ab1d-5dc16ad43519"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("daab110b-0e5e-49fd-b770-6a01442f9659"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7860), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("b43244fa-f6ec-4dd6-8ca2-9da0b4244945"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("6322c859-e2ad-4482-8877-d209ba7f57aa"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("53ef1a7a-d224-43ee-9d26-8b2e6e1487ac"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7899), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("e05c292a-1f38-41e3-8b74-258de542c66a"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("cd0e679a-333e-47d8-b1d2-1181e0fc3fb4"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("bcd7b6a0-64f0-4c9f-95d4-c8ef40ab2517"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("e49a2ca8-4ca7-4e48-baa5-259d736543e8"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7936), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("0fc18f6f-13e2-401a-a2d8-2ae0fa6cbe68"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("6c00dd10-91ec-4515-95e4-165ab537eced"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7954), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("ea4e9c62-1fc3-44b5-b402-4162e62a930a"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7963), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("6faf9c6e-74ad-470e-b5be-d83a9ada4259"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(3933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(3957), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("2eb98694-3ce8-4f96-9f77-6d7c630a17de"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(3976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(3977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("6a048255-be5c-4f7d-aa20-07fd19a19b79"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(3998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(3999), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("0f5f7743-3b6b-4812-8b65-73f51a644d9f"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4011), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("d5b208ae-bd6b-444a-890e-c1d2a2d61624"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("73968078-933f-4b0c-83e8-925375a00ce5"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("badf5168-bb66-4e6e-bbf6-da22d523f99b"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4108), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("8b46cfde-701a-49e2-a8fb-d8efa41eba60"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("9c53a6d3-edfd-48b8-bca2-15aca756eb6b"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("60dee77d-998c-40af-b9ca-e4523e0c82e5"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("0abbfbfa-f898-4b6a-b5d1-d26cf3573609"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4159), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("f48cdb5b-177e-4471-a103-42c5cf364cff"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("a54444dc-3dde-4a04-b849-8f98ed6be777"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4183), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8464), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8521), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4831), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("34685df0-2655-429d-80ce-dcd803df877f"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8833), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7fbccce-3d90-4265-90ce-0272b140a75b"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f2d6f760-3b97-4f6a-8169-a617070f2956"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d328e5d1-86b3-404c-b9c7-5644ac439ae2"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9eac3b36-0b89-4a41-8dea-85086e3f44b0"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8845), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1c676333-3d90-4ca2-958f-8e9d2fc4a4a7"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("93ab2fea-a127-42a6-8c1b-bc34bfa6bd5d"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3141c460-3d9c-4932-a851-b55edb518f1d"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("d43e3e71-3628-4ade-9cd8-82cad8d086f7"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("7e52aae3-1023-460f-9c5d-24b296ef7ef2"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8862), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("73c9744c-ef37-4f22-90aa-8ff5ddab956b"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8864), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("acc19b5e-9dd7-460f-9cec-8745749af2c6"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8867), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("db8857da-05c4-40e1-9b5b-4d906f233394"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("1c902264-c40f-4b4a-9859-bcdd72f81d71"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("773f5cf7-f49b-4848-b49c-7f1a7cf4f8af"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6b6b20a-0b51-4fec-a67f-b8fc418142a7"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("62df3792-4b91-439a-83ea-c59cdc2846ca"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("79cf1623-5af0-4f27-8a88-a71a64656712"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d81a4a3-7527-4f60-b006-ccb699f57b49"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("80c78efc-64e0-435a-8017-d5d9606d0ab8"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("988a759b-63bd-4446-9b70-f17b716469e1"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8933), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a59a35a8-c598-44c6-8978-c2c865d5fa06"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8935), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d9d8f272-a3e6-48d6-a2fa-8f548cdd9733"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8939), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("342b0709-6432-4b70-9448-c49d6555d405"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("58d6d970-e4c1-45f8-a2c7-fe7a056a3996"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("03a6a354-7fdf-48a4-9cb1-7efb381d9afc"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ee427141-54d2-4b1f-ab36-ff652fffd73d"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("82b90967-e20e-4f5d-91ed-618df44cd132"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("44e08d69-7766-4505-a537-d7d954855f38"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a2a1a3e-1df3-4dbe-9b76-6bde27ff06ba"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8957), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af191a4d-e6f5-405c-97f1-9c101793542a"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a5959626-ab86-48f4-a69e-080dee61610f"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0b5ef008-014f-4b9e-becc-e29feccbae82"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8967), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dbc3eff7-406a-43ff-8ab8-e07ce4ac03e7"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8970), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c8e41870-743b-48a0-bbfa-8907a024c517"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("777b8ff8-316e-459f-b726-c11771b9f56e"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("9571ace3-1af6-460e-8fd7-31094548534b"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5a9d192a-4420-48ee-b078-6339a5e8910b"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("41a7daa0-3d8a-4e7e-872f-75ab27f58664"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8981), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c0f5389b-90c1-4c4c-8835-4cf20dd37a76"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a732c81b-8b65-45f7-9b38-55011b2defb8"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8987), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7fd6dfdb-0995-43a2-833f-37ad84418722"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8989), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("b349f8c9-31cd-4f3f-8b2f-72d4a8a65ceb"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("62b7505c-8d20-4a39-ad86-a9202dd6a57c"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8993), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6b7deb6e-d04f-4433-89c2-97fc53f5bd57"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8995), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("96a665bd-8945-441c-8111-e3df012907dc"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8998), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e64cffbd-50f5-4cc4-a12f-e47bbb62ff45"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9000), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("669281e5-463b-4597-ab2d-0767b9332762"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fdc4811f-0460-4e4c-bd83-0d1caa7cad97"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e44125e-7b8b-4af1-b94a-7288ce439a86"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9009), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("88129499-3452-4ede-acfd-e07a8f5e0851"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9011), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8c2fbcdb-8a63-41c4-a75f-fbed1122bbb7"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3403f9be-90a7-46ea-ae3d-cdd26137227d"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9015), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("20e703ed-1437-47c3-bd2b-b1974de07853"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3b35956f-4577-429c-8655-0a2dd3df3870"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4b56b0c0-cabf-4d9b-ae1b-84b869f7c7d1"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9046), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("92488346-5e3d-481d-840c-c2c1c9a8e17f"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9048), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e81387ba-c1bb-4810-89a4-367dc5e5de8f"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1067f4c9-4851-4635-a4ad-f87f63f97e87"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("33cb3367-67ac-464c-9640-ad1fcb1740c3"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9055), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("46702a35-901e-4223-9ea9-014d1a8991af"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a0ecb1e9-cb3a-459b-8a88-853fa84c2097"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9059), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ba110c1a-ada5-4b4f-a5cb-ce30c2fd39e1"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b1b33276-2352-4b65-b585-1c00a699da1c"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7d6ac4d4-abef-4398-9b2d-169ca5385c13"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c1a0cf09-e8af-4b40-8e0e-b3cb29f57a1a"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("75d30f18-5c38-4293-93dd-f61b47be4e59"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9073), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e34acb02-2311-4473-a3ea-7611fa7f7aff"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9075), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ec81f13c-a82b-462d-a680-4c3faeda5af6"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9078), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13655bc6-98f2-4915-897e-c94856fe967e"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9080), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("9f46a077-e528-4379-b8d6-8f1ae45fc404"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("34531eea-c514-4b27-97a5-52f227faf701"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9086), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c96aa220-497c-46c7-a783-e5ff7bdbecdb"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8acf5156-5943-41e5-8a1e-fab66fdfcaa6"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("801739ba-0399-43d2-bc99-7b2b1300b570"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7bd2b34-0800-46e3-a9a4-d61c2f299bbd"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b83773a0-35a1-4bb1-a587-7053aede4156"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("03508a90-6297-44a2-8ed1-e195f81184aa"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b05b97a2-bbe1-4e35-b17e-9a6c149ffa46"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9101), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9a182a80-c92a-495c-aa76-3c7da33576b4"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("c802d9ed-a59d-4851-a2f2-fb15a41269f1"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9108), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("6d25a770-99db-4667-80ff-1c3ce239366f"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("d7a1d1bc-3eba-4606-b2c6-d4cb012fa079"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("2d483cd2-5232-41ea-9252-8d9a69b96670"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9114), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6011d50-80d7-4098-b3e6-c90cf5a95769"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8937), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("75a943b8-ce41-4c86-ab9b-be9d860b453d"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("439b409d-7612-4c2e-87b5-3e359d6cc24c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5281), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f3e2b891-4f39-452d-a06e-e81d08b470d4"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5284), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d2b7041d-6315-4724-a5b1-3f9929a8b1ff"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c494f204-c9d8-468a-bda5-1145fa2de96c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("19992df9-cb88-47e2-af79-2e29541cd3d1"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5304), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("148c7e87-c57c-498b-8936-56d5f0ed38d3"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("538264b4-754d-4238-9c40-0479493e9f5f"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("275a3df4-0840-4ece-bb60-d3e1da2b7d46"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("72cb26ba-15d6-40f4-9d15-6e5c922b1c5c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5317), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("045f9486-6325-48ed-b8bb-3465763fecb6"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f6155671-afc8-4402-a2fe-32540aa325e8"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5324), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("86b28393-71be-4879-a665-45de9f80df98"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("959bac61-9e13-47b2-bdd6-abdf71955e37"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5333), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("67aa3bbd-bdb9-44ec-8440-95c7b932c5cd"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5336), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("afa9d6ec-d6a8-489b-beb0-37bc1f95e1d1"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("954b0a80-9b8b-4667-9d2f-b327f61a3499"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b4115e36-5d78-43fd-a420-e5c028783ff5"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("71abe904-8a37-4312-a0c9-870da990237b"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0082a638-2c72-449e-9e32-e3dcc3165442"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dd80f45b-4ada-401d-a307-f587a705faa4"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5354), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("242b0997-1e5e-427c-8ee4-ab4ff4db08c8"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("461ce3a8-c441-41c7-af82-6644cfc2c044"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a9982128-7783-4fa4-8474-65857e41cdd0"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5370), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5ea3ac5e-2f00-4a06-8b19-2f1b7ba25051"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7cc9e6ca-0efe-49aa-9bda-d2f2e99863a8"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5acddbb5-a962-4ca2-9a2c-91362b4a78ef"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5379), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6092846-c1e1-4a64-9919-37efbfcad12c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d00600b7-3a35-488b-a97b-542f740ae3fe"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2ad46359-5067-4a5b-8576-580159be6b45"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b0378c62-b42f-4932-a984-2b28a6c51797"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5393), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fa735513-1d76-4311-ba81-2f2ff85d2f92"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8dfbc496-c76f-418a-bc2d-a9301b61170c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5448), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("717ee950-525e-4c71-80a3-4f9c433bc791"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cc4ce4b0-f192-4493-877b-d8a8bf480de6"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ceca582e-be55-4d07-afe8-3f27f5170e01"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("ea7a9de1-d43d-428e-9c5a-22b2446191f1"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c665dea8-d940-45c7-8cc0-ae36a1a7cda7"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5466), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bf9e0f4f-12b1-42a2-ac95-aa393de6194b"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bcac80dd-ef16-484a-a9c2-3e06e2efff75"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5472), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ddeb612d-6b22-4a14-86f9-2fcbed9c2471"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5475), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e1a23067-183e-48e7-a773-061eebb7ccc7"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("fd71d39e-b610-4e2c-9449-81a06967ee26"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("833a51a1-f319-4767-afd7-14462d957335"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f03ee2d5-2b9c-4bf9-8b0c-eb5138a9b76e"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f252202f-d96d-4a86-9457-1de3e87c3db9"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5493), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8348cc54-973e-4705-b2ce-279393a83ffd"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5496), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("826f7fc0-97d3-4885-a48d-b752d2b3bc18"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5499), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1ca32dd6-75d6-4816-b55c-1d2851b22ef5"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d0bfbd3-a13f-4bc7-8dbd-33ebee3b6297"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("031ca1f1-2a3d-4cee-9bfb-bea0ca903e5c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f1b5b9eb-cf9e-41ac-afa1-4e3726a8b954"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("37856f11-003c-4451-bd31-06ad9b8abc6e"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c15b93b2-a9c6-4c91-9b82-9aaa5cc1c568"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1a1c377-803e-4988-87d7-599f9e702e83"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("261386c4-cc56-4f43-b2fb-761ddb70d892"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5524), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d754f1d2-563d-4dad-9319-36b715c96c60"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6e858d85-0c7c-4a6f-9df2-7ab0507ad4ae"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ed55d16c-2573-4e37-90a0-b53dccbe7873"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6cfde001-38a2-4829-82d9-e33dd40ab933"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4ac559f3-f38a-42e7-991c-3ce0c7bdb258"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("081394ed-2181-455b-9051-7d7ad0a67b7c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5544), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7063690b-4e4e-400e-aa68-aaaf96aceab6"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5547), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e84b10df-20e5-408a-ad87-db1f3ee694f0"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("19b6ca39-9dab-4d9b-a648-a715d62fb0f4"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af1d418c-ab7a-4faf-88ed-975ebf3ec2be"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5170c26c-679d-4533-9a23-5f0d88d53f00"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("22447da4-7b80-4e90-bc73-39b477320d48"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5563), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0f27abf6-51e2-4d0d-aa1f-60256a4decfe"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e9cfc46a-4b4e-489f-9813-0a8de6ec55d8"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("a3a4b35d-a837-4efa-88e0-b6cfae2fd08c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("430cc16c-0796-4771-bfe5-f02e95da4dba"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f50f77ca-7524-4885-a42b-fe8270dd12d2"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a8f15c5-c278-45da-97b8-b864871048f7"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("82c84980-d673-4dae-907d-7638d2b20f93"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ae08ea8-2409-477b-a6d1-8f1625895071"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dd1b7a89-a143-4f7f-8dff-27aebce053f4"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5638), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3860f89b-7794-41e4-8570-8cf96cca2635"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("39104cb9-5a2f-471b-af9e-5d0503e0d515"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5644), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("bffd57e8-73f6-4611-9de6-0b42b131dda0"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9b46daf7-c5ba-4956-8fc2-aff867981b9c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9da84870-2616-464b-b948-288587ae2f9e"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5652), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("6ba92f05-d753-470c-8110-eac0e9e4107d"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e3f81774-26b5-448f-91de-88f1ae45a952"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5658), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a83aa131-e5af-41a0-9d61-c2f03fe55f87"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5363), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 10, new Guid("1b7e2aaa-bf52-4aaf-b687-9990025d36f5"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("a49687cd-0d89-47b9-9daa-dfb9210c4d0d"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("6a9b58b7-02ab-448b-b7d2-095f7a559fbc"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8152), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 10, new Guid("f77c4960-c51a-4ed8-8527-715de8a29e8c"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4398), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("f81496e0-81cc-415d-93ae-a9b0bb925061"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("e345d811-c4e0-43dd-a044-0ea020e8f1fa"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4430), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, new Guid("2ea7b52a-e9d2-482e-a503-62b86251a0ae"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("fe4e1d52-f1f2-4d9b-8068-1f2f3977b7be"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9220), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("f2ad9e72-ca84-43ba-86ec-8b66643f5c1a"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9233), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("2c625d2a-a6bc-4e92-a5d8-68e49a16528d"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("512e9906-5716-496e-ba3c-2458ece90610"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("a99c7ab8-55f9-49c4-9581-fd2dfc55118d"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5787), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8381), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });
========
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4738), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8389), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });
========
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4748), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8398), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });
========
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4759), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });
========
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4769), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8414), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });
========
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4779), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8422), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });
========
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4789), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9172), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5701), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5707), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9246), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
========
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5795), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5801), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8671), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8691), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8710), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
========
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5023), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5047), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5071), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8454), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8534), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4820), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4863), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, new Guid("52027a9e-10a6-4c06-9cba-aec2d597b827"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(7984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("29a53b6b-73d6-424b-b86e-c401d267f6b1"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8000), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("af930991-33a2-43ab-8525-77576bcc5f6f"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("e28eef52-c16a-48e3-b025-ffa8dd4f44a4"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8064), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("07d5ec68-de71-475b-92d5-a394ecc981f9"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("e3a66cd0-2664-454c-b686-ca767d03461e"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("f0162df6-5ad9-4511-8a9f-43ba58daac7d"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("fa80e251-853a-4a17-a548-d7b204c82eb0"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8108), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("2cbc92e7-5aad-48f2-be89-4a803a5e13ec"), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8120), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("24d2c9a8-b254-4e79-abaa-9f7819810c47"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("58481fa5-67df-44b2-8566-a8caf3c94010"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("1f11583d-c246-4bde-b3c8-ef3f1ed25ef0"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("4b591d4c-fa83-4128-8827-7647391d42a4"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("235a9a2a-283c-41ac-b926-5b05d6fd1a49"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("dd4b63f6-eb27-474e-ab5c-902bad76b5c4"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("db5c2888-6cc8-413f-a43a-dbae7d670c5f"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("168da84a-a13d-4ea2-bea4-2fd931164672"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4317), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("e1ee5639-51bc-4670-b07d-36640d8dd24a"), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4379), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8167), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });
========
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4456), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8180), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8189), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
========
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4470), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4481), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8198), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8222), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
========
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4491), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4527), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8276), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
========
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4541), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8286), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8294), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
========
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4573), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8304), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
========
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4585), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4596), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8321), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8329), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
========
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4606), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4616), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8337), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8345), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
========
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4627), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4637), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8354), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8362), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8372), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
========
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4647), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4706), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4725), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9259), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9311), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9318), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9346), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(9367), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5995), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6011), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6028), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8546), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8649), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
========
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4877), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(4993), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8756), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });
========
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8778), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });
========
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5209), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8796), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });
========
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221001125708_InitDB.cs
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 1, 19, 57, 7, 666, DateTimeKind.Unspecified).AddTicks(8812), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });
========
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 3, 21, 55, 23, 455, DateTimeKind.Unspecified).AddTicks(5250), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221003145524_InitialDB.cs

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
                name: "IX_banners_file_id",
                table: "banners",
                column: "file_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_booking_detail_drivers_booking_detail_id",
                table: "booking_detail_drivers",
                column: "booking_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_detail_drivers_driver_id",
                table: "booking_detail_drivers",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_booking_id",
                table: "booking_details",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_driver_id",
                table: "booking_details",
                column: "driver_id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

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
                name: "roles");

            migrationBuilder.DropTable(
                name: "booking_details");

            migrationBuilder.DropTable(
                name: "fares");

            migrationBuilder.DropTable(
                name: "promotion_conditions");

            migrationBuilder.DropTable(
                name: "stations");

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
