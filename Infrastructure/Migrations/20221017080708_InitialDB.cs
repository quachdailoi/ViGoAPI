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
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("7695a9af-08ec-41e0-9051-a00858a2679e")),
========
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("779c8d3b-87be-4868-8188-230879f9a098")),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 657, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0))),
========
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 158, DateTimeKind.Unspecified).AddTicks(4631), new TimeSpan(0, 7, 0, 0, 0))),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("bdb8a235-8677-45ac-b1d2-9bbbf72d7454")),
========
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("7cad3b1a-e647-43f0-81bf-1995fc99bfcf")),
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, new Guid("1da6c5b4-48e1-4da6-97d4-397639ffe179"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("6dc1c059-0ff4-4a6f-88b0-baf1e37d12e3"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("81d50043-6a36-4447-9cac-28e70eec2e21"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9098), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("6e4dcec2-a91f-4ec6-971b-c11c89558104"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1279), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("90c194da-b21b-444c-a825-d372f11150a6"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("ea9b1cb2-6333-4591-8a48-9512c3dd024e"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1292), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, new Guid("b3ff0078-7ece-4df7-8a3a-b8b2f8c4a50c"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7764), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("cc3605ea-b103-4fb3-802f-4360e486c5b8"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("9e0a5f2f-d4d6-42ea-8e8b-4ba120522aa1"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7787), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("f8626910-2726-4dc0-bf76-b720a9fddd41"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7795), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("c6a95e81-b5dd-4fea-8072-279c79e0aa1b"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7809), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("cd11ad92-c5e6-4406-b9b2-07f4c4604f49"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("5d5f9d45-b3fa-48ff-9121-3dbbd91c79d5"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("58ce0549-ff0e-46d9-b781-dd9b35e02616"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7845), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("69b2bf40-dc57-4116-94c4-6dcb908e5a3b"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("7bbf0091-1578-4c1c-a74d-2c9e6ce5196a"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("b067b39b-dc44-4940-ad80-d24843f1b029"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("06334349-5d3b-40d3-894e-2270e322f987"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("ae1887d6-637d-4871-9224-aaf7484e1fda"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7887), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("c0a7fef2-700d-418c-829c-5c578619f444"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("8dacba3a-15c7-47c6-b967-36ce4f5af0ac"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("b37051cb-91bd-45ba-a288-f31e278e6ceb"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("8fa6abde-fbae-4ef0-9ae0-3aadb8bc7deb"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("f90a4810-5514-40c6-abb0-2c59d7f50029"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("1c62b49d-7eaf-4914-b28b-b7230c0eb072"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("f28eb77d-8b2f-4f3d-891d-a1450a6cf467"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("c364ab6c-966f-40e5-b0a4-dffb52e398f8"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("2fda5fc7-fda0-432a-93db-2ea49922f06b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8922), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("57137667-128d-4aa6-89b4-e205be326f40"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8933), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("0bc6dd40-ff14-4c91-b33b-19d9fcccd530"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("8d3865c5-bc17-43e6-a64c-1e08c55df2cf"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("0f7b0c6f-eee9-47de-b13a-09a00eb1f1e1"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(8969), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8275), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8282), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8290), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9766), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
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
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("bab7ef10-65b0-4de2-917e-dbecc8bac683"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c1bdba02-bd3e-42aa-ba9a-9bf2b9880ffe"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0d0cf023-4ca3-4afa-b726-05ca133fee5a"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("56858c0e-e80d-4a3e-a701-0a2f4ca91b93"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dcc39f05-59ae-43a0-800a-7dca52178223"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d74ea20-ace1-4b7c-9583-25defeaa5d01"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8584), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fe367d38-baed-496c-8559-5eae68736eab"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f55280b4-1289-4b93-b5db-58b543abc47e"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("19a2a165-e7ff-49a9-baf4-6377440cf1a2"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e35b76ed-6025-4df6-b951-a7afd02339d4"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1161feff-d551-4a08-a094-84f4540b6b7d"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("826d4e3f-d5f7-40f9-ae6e-7cc6851edca1"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f9b5a1ae-e029-49a1-b0c8-cbeab01173f3"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8602), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("585319f1-00c4-4495-8bf4-5c6e820bdf4b"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8604), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bc37a611-3bbf-44a1-8331-92405b9e4316"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8607), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c480916c-189b-481a-a5b1-5fa3992e290a"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8609), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("141feff0-1656-49a1-b24b-55724424bfbf"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d7181dc-4d2a-40c7-9255-589b79ba70d8"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("132734f5-ae85-431e-a77b-bcd4005b92e3"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c3a291f0-f932-444d-938f-b6adc56e89cd"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0d9d848a-c947-48bc-abef-0169726ef22e"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8623), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7a47940a-cb2f-4db0-8dcc-5b07deee1d15"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("633ceec8-7ff6-4ad8-9668-3fc8ef858699"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a30972cc-ab02-4769-bdd6-4e451681c1d8"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8632), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("378aa22e-338d-4e8f-903a-121524ff1781"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4701731a-be79-4650-a19a-227a177e489a"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("87585091-c942-4ef0-b466-2a64489d300e"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("91437f15-4844-44dc-8897-a90745f364aa"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8643), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("31721364-54d3-4d92-abe9-b4c967f26a06"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8645), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8732844f-1da6-424f-a74c-89f871799211"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("11c5d44a-b513-4a4c-84a0-36a3c3e6dbf4"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8653), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("07ff10bf-eec0-4ebb-b4fc-5bb885e3c50a"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4aca3c94-aa76-4482-aece-c5e5806d6234"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8660), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2923dbee-4427-4904-b53d-732caf9f1d41"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8663), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9ebbc8d8-76c6-418a-b1ed-291382c32798"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8665), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ea7e6a80-8828-43b7-8308-4f95ca462c98"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8667), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("b2c08bbc-7d17-49ec-a573-a15bb561da92"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8670), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7569ba45-ea63-4936-b6f6-81df013416a7"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a61c3214-f959-44f6-be41-bd0286960a67"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8674), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7c9c3b08-2f6d-4463-abc0-432421eeea4a"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("28bf7799-7793-4a19-989b-844cc173fc9f"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8680), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4be731bd-e600-4549-81e1-3438664d4d2b"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("aa8676b0-1f85-426c-b2bd-4d8ec6af906f"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8685), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("2926b611-6b6d-423a-825d-7dc2531f5b52"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8688), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("12def66d-c468-45ca-92ab-5a609b730d75"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8690), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b53c82b5-c98f-44e1-85ad-de757dfc7133"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8692), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("edc51df7-969e-486f-9e92-c5bfdb903ace"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7de8441-9e43-47ae-baa6-239d7cf5c61d"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8696), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7d19600a-6610-4f8c-b492-d36e1cf51e2a"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8700), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c81a65f0-a6c4-4262-8bdf-2109f9cd01a5"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8702), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("88d64978-9657-455a-9fcd-e9c03db36c51"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("64ab8cef-7f25-4342-9515-b252b92cf35b"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8707), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("87bc6f0f-fd55-4f57-9bf7-7e2dce19e827"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d92f193a-632c-4777-b225-a514225f89c4"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8711), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("55134e0a-75a3-4696-8688-ed3b487ea350"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5f5d9c73-6ed4-4ae0-9a9b-56c0054a3f26"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f6d1de00-3b46-4bd3-876b-8bfd78da6f37"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8719), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e69e00ab-23b7-42e2-9e69-ce8567584a90"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8722), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df3aac7e-f82f-4f20-bebb-c9d892e675e0"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8724), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2a9328f8-297b-4920-ab6f-a8b536e7534f"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8726), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("254eca31-82cd-4f38-b44e-2b9426d4f9d1"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8728), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1e8cfe0e-e1f4-4b9e-afb5-ac6d00d2d5f4"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7877791c-b59f-43b8-abd3-5c9626dbb825"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8732), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6f0b6e2a-fda3-4d9e-ab50-9735223cd275"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8734), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("638522b3-7e98-4807-adb0-a7bd11252f01"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8739), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1590227-9749-4cb8-85e2-9f787a2dbb17"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8741), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("05c4adac-de05-46a1-8af1-2294d547acdf"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8747), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8ddb5742-6d7b-4b6a-a074-e444ab4f3d86"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1fb88456-b392-43c1-9904-f7c9f56077a4"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8752), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b5bddf33-a280-4ac0-86fa-551ebf225f1d"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("94594e28-2551-49e8-bb31-24ddee2b85be"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("83399dda-8bb0-4265-bfa0-849e61f0ea00"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8759), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9bc1a14c-1020-44c7-a29f-718da935a696"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8763), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c390c391-6f08-49b5-af41-a1c48a5fd2f9"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a15a5dd0-5600-4630-88fd-898516515a19"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("63134bb9-c220-4e73-816e-56f48c162686"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8769), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e723362d-efba-4474-8669-c03a288b8edb"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("44ea08c7-2ddf-4d71-94a8-96c3a98ed6c5"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e9911f8c-9eef-4cbc-8b92-411d07ee7ad0"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("742efeb0-efb4-42f9-a241-9228316c4386"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9de7a3e0-18d5-459d-b740-327d2b396f5e"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ef1b4507-de65-4a2b-a7dd-ddf375c00aaa"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8784), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("37d0b2ea-efbc-4005-a025-a29723040496"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("be492a79-d14a-4e4f-be6d-7d6430b9fceb"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("25ed4fa9-e319-44d3-90ba-f28bdad7581e"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8628), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("a10ce880-0451-46ce-bd56-8a5f5e32d187"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8790), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("a28ce41d-e6ce-4fd1-9abe-a8eed4fb364b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a9cc48b6-2746-4db1-88c1-90b71f224787"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2d60b2cf-da32-46a6-9087-f41f7800eb1a"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(229), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("efc2760e-3e5d-440f-9121-1a96f1d75479"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("08745632-d5d0-4925-89be-bba7f02afa38"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(235), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13701564-9b4b-43cd-9e8c-be8ddd560459"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2718ac83-b362-4fe5-a9de-5368e93d2bfe"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(242), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("847274c5-425a-47ec-bfe2-5615208be2ea"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("4040f60b-3258-42b4-b21b-8217d48cd3bf"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b6dc9e04-2b46-4b3d-b7b9-51c26abfb884"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("653bdf3b-28a9-404a-af93-cc90f1f7cb0b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(260), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("642f7899-a67b-42c5-921a-2f9ce439f893"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dff975d2-6b4b-45b6-a922-360f928ee9b2"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("81369c78-a931-40cb-a587-9193605c0dcb"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("21d1595d-6bfd-4abf-8f85-8415bbdb3e32"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("78399027-a70f-460b-b67c-bb30cb5f34cd"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7943afe0-34ae-49cc-a0a3-28104f927891"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(331), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d05f28a1-e037-491b-b849-c75001a124a8"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(335), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dc59ab03-ac75-478c-a128-3f06d16a5d2b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(338), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df4ed41d-6284-4761-9315-fa8382b58d8c"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6c948b85-0ab6-4744-8368-2e75cc48db62"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29b43532-6f55-4cc8-a21c-8b74eb7ad75a"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad2abf1e-4e11-4e65-8261-181fe68157c0"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dbf45116-aa5e-463a-aae5-3f101b86de20"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e7a962f7-5234-4008-851d-92e225cc8e73"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("20da4683-5325-42f4-b81a-f05de3b0e1d5"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(366), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b7e6376a-53df-41b5-b87d-dd7f32cee644"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(369), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5abe1e41-1584-4a4b-b820-b37590aa5411"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("91d96f69-e48c-42f6-8229-daf440e24ae7"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2741bf81-a8ee-45c7-96a3-cefe0e9116e5"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("32d23f53-c8f2-4b8e-a22e-ef4051b44959"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13861c8f-60be-4739-bf3f-2e9a1a5919f8"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cece21bf-42c3-48c4-aca3-06e87a67daac"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fc15c438-0fd4-4167-9e3c-9720c32aafc9"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d09579f-2760-4b5c-9b52-f40a902efbee"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4a2a47f9-ed26-4d71-b54d-8c93fdc7ef1f"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("74dc902c-1dce-48c2-aff0-e984a40b052a"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8162cc23-526f-4be9-b7c9-c4afee10af8f"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e56109a-bb64-4da6-867e-4f1e883fca1d"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(413), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1c63943b-01eb-4524-b138-21051faf2418"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(416), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8d484f42-8eeb-46e2-b77b-dfa58e409c36"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(419), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1bc50876-c87c-4f61-b2ce-464e10bb6889"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("94673d92-1032-4fcb-9bb8-1d951ca43010"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("ced18452-5219-4899-a5ee-e3a21fe80573"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6c780659-4c1a-4273-a342-73b9f57c5dc6"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e7f2816a-8155-42bd-8af9-90bae23b2d10"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df6111f6-3839-40fc-9465-052b47ebafa7"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("78743119-1721-450a-8526-e60f7966fe4e"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2d22964f-c055-41c5-98bb-7af301d69fa0"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a484147e-577c-49a2-8f27-9700bc87d4dc"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d40e5f9e-fc3b-41f9-9c9c-596a702e7f87"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("152ff3c8-ae6e-4b06-9b39-77bf428e5718"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d27b3653-00dd-4034-8df6-8cb956988b06"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9664cf82-851f-4cfd-82e7-d80cb6a155fa"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a1eea9b-503b-4f08-b581-38eaff18df1b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("736a12a3-478c-4e8f-b269-fe28113978b9"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ac93b7b6-9139-48b2-a27a-5185ce6e288a"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b1dba1d8-8705-4934-816b-b5d75f0c130c"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("51eeaf4a-97f6-4350-a926-d2f286009d71"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(528), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("468c7514-c2f8-4493-a909-d4280cd3b42c"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(531), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dedb2ff7-74f1-4b1f-af8a-d105e5c7ba73"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(534), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6190be7e-22f6-43d6-970f-137e8b1bc68e"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7d07f9f1-8029-46b8-9434-249db8f08b86"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4b888297-761e-4535-9bfb-9b3d568b4696"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f0a7c806-050d-41c3-b445-831668fb2515"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d7f804be-41cc-4876-8b37-7f3dc2dfdff5"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f10b1542-2097-450d-8631-c5d447cf702e"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3738c881-793f-4507-9788-bca704b5d7b4"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("641408ed-927e-483b-aec2-e32d6aa3f7ad"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(563), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("06d6b51a-70d9-4417-bd3b-12dc24f61408"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("3c0eede4-57ff-4f57-b806-0ac6f211a808"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("675b6420-1fa4-4a2f-ab6b-4a67c4418899"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2029a2e5-3063-46be-8aaf-3d1714a488dc"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(578), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("45495401-19ba-4780-aa6a-34cbc156ba81"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(581), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("21ab079d-b07d-414a-a0e1-a7d840bb3d67"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2bc46af6-c74c-4473-b72e-54311fa3c435"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("64d7bc19-9372-4783-9c02-4451374884ff"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(632), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6d1f3f7-16c2-4070-9c71-895b8a4ad10b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("14f72105-708b-4ab1-9f3f-79b35929c98a"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("34bd98ca-882c-466c-9238-38493b63eac2"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(644), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b334d8e3-9190-46fb-9679-1f78aed7c7bf"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("7a4e35ea-6562-46ab-a08a-56487a53bd56"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(651), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("539d2f1f-a9ba-4b09-ac72-ad9746ed137b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(653), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ee676eae-df31-474a-8f03-33904f956873"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(656), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("104b0819-b626-4064-8717-402076f48553"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("267aecff-6df7-440f-84f6-c071426187ce"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(659), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 10, new Guid("cad42654-892e-4227-9ba0-928be95e9fa2"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8012), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("773131dd-4f37-40d1-b62b-b475b366f5e0"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8022), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("128ddeac-adfc-4ea8-8a27-ed849ba30332"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8031), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 10, new Guid("2d706a16-31fe-4636-b7fd-2509213bc41a"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9261), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("6c5dfe23-760c-4bad-af2e-56be59e9229b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("ac6148e2-ce8b-4b5d-bf4e-01ab4fb217d6"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9286), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, new Guid("632af7c2-ccc2-47b1-ab28-c9e4ad0b2dc3"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("7975d2e9-7d62-4528-9f47-4ae8e3935052"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8873), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("c7284fc6-0e9d-436b-bfbf-14e8f16040a1"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8885), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("0a5e28e9-8add-4a35-ab69-8f47edec1f31"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("5d6e2748-e078-4f1e-a05a-d97c25c5fbd9"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(809), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("7460eaf4-2fc7-48fd-9373-7078c2e1ad84"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(822), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8207), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });
========
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9573), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8215), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });
========
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9582), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8222), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });
========
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9593), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8229), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });
========
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9603), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8236), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });
========
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8243), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });
========
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8825), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8827), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(709), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(719), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(721), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(722), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8892), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8904), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
========
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(845), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(860), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(863), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8425), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8442), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8459), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
========
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9967), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9995), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(23), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(24), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8256), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8299), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9781), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, new Guid("ec2f1e56-473d-4d78-90ed-5fa20ff7c86b"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7904), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("80271610-1f61-4a11-9cb0-f873dfe01f17"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("ec7eda0b-cb9e-4ad8-96ba-99b22fbea5ca"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("d095e234-54ee-4a55-879d-d4005be479a1"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("5b2ba066-81f0-4341-8880-580696eac4fd"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("cc7d3ed9-7558-4ac0-904c-fd090b4e15b7"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("bb2c1595-aaf2-4693-a8d6-2a674b1a5676"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("89a16c54-43e8-48e0-add0-fadd6051bef2"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7988), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("f0112401-bb02-44b1-9021-a294c4791559"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(7998), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, new Guid("6977ac7f-b5cd-4ab6-8d0b-ce89d438b17b"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9037), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("bf7a3fb7-0ca7-46f7-87c6-eb497b6af4fc"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("6507890a-b722-42a8-afb3-3603edc08fa7"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9153), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("546e6462-af2b-4f64-b9a0-701ba0d5a7e1"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9169), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("502d6bec-5c0d-4dda-9f9f-ba63d54a3f51"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("8c879b2f-3bb0-40da-840f-5dc60f386dfd"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("5708748c-1bee-4bf7-bfc4-c2e43b7dc432"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("8bcf31e5-8301-4c3d-824b-62aa7f24b700"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("dde77239-63b4-433a-9ee5-de8b7bd7e64d"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9247), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8046), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });
========
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8075), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8084), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
========
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9342), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9372), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8091), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8098), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
========
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9382), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9391), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8108), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8115), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
========
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9401), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9459), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8122), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
========
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9471), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9480), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8137), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
========
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9491), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9500), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8152), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8159), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
========
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9518), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8166), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8173), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
========
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9527), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9536), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8184), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8192), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8200), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
========
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9545), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9554), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8959), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8965), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8978), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8992), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8999), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9020), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 7, 0, 0, 0)), 0 }
========
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(888), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(971), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(980), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1050), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1072), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1132), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1173), new TimeSpan(0, 7, 0, 0, 0)), 0 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8478), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
========
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9800), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 179, DateTimeKind.Unspecified).AddTicks(9938), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(50), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(51), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8502), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });
========
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8521), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });
========
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(134), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });
========
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(8548), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });
========
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(168), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, new Guid("39cc4a80-bc95-4fdd-94b3-8007e5e8abc3"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9058), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("9405a838-5028-41d8-9d00-07e2c418d1c3"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("36366e4e-d162-43b2-829d-d508ce791103"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9063), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("29e6d993-f5f3-41d2-a59f-d4e838e76b6c"), new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9066), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
========
                    { 1, new Guid("65bab531-737a-4656-b050-852bf21cd873"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1213), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("229b0b9e-9daf-4c12-8d90-1080a0f94131"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1222), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("39dd1293-bd91-46c5-90d1-755c89d1bea2"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1224), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("49e3d4e4-5d6e-4400-bb49-07e3b777ea5f"), new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1231), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20221017063401_InitDB.cs
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9114), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9117), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9122), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9125), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9126), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 13, 34, 0, 667, DateTimeKind.Unspecified).AddTicks(9128), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
========
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1321), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1328), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1331), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1333), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1338), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 10, 17, 15, 7, 5, 180, DateTimeKind.Unspecified).AddTicks(1342), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
>>>>>>>> booking_datdt:Infrastructure/Migrations/20221017080708_InitialDB.cs
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
                column: "message_room_id",
                unique: true);

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
                unique: true);

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
