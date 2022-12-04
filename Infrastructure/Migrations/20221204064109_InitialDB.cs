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
                    Id = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_affiliate_parties", x => x.Id);
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
                name: "license_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_license_types", x => x.id);
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("be6bd549-af76-4d05-bd2a-b8307023f14c")),
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
                    name = table.Column<string>(type: "text", nullable: false),
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
                name: "setting_data_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setting_data_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "setting_data_units",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setting_data_units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SettingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingType", x => x.Id);
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
                    id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    slot = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
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
                    expired_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
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
                    rating = table.Column<double>(type: "double precision", nullable: true),
                    cancelled_trip_rate = table.Column<double>(type: "double precision", nullable: false),
                    suddenly_cancelled_trips = table.Column<int>(type: "integer", nullable: false),
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
                name: "settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    key = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    data_type_id = table.Column<int>(type: "integer", nullable: false),
                    data_unit_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
                    table.ForeignKey(
                        name: "FK_settings_setting_data_types_data_type_id",
                        column: x => x.data_type_id,
                        principalTable: "setting_data_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settings_setting_data_units_data_unit_id",
                        column: x => x.data_unit_id,
                        principalTable: "setting_data_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settings_SettingType_type_id",
                        column: x => x.type_id,
                        principalTable: "SettingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    promotion_id = table.Column<int>(type: "integer", nullable: true),
                    total_usage = table.Column<int>(type: "integer", nullable: true),
                    usage_per_user = table.Column<int>(type: "integer", nullable: true),
                    valid_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    valid_until = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    min_total_price = table.Column<float>(type: "real", nullable: true),
                    min_tickets = table.Column<int>(type: "integer", nullable: true),
                    payment_methods = table.Column<int>(type: "integer", nullable: true),
                    vehicle_type_id = table.Column<int>(type: "integer", nullable: true),
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
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_promotion_conditions_vehicle_types_vehicle_type_id",
                        column: x => x.vehicle_type_id,
                        principalTable: "vehicle_types",
                        principalColumn: "id");
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
                name: "promotion_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    promotion_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    used = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    expired_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
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
                name: "reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    data = table.Column<object>(type: "jsonb", nullable: true),
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
                    table.PrimaryKey("PK_reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_reports_users_user_id",
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
                name: "user_licenses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    front_side_file_id = table.Column<int>(type: "integer", nullable: false),
                    back_side_file_id = table.Column<int>(type: "integer", nullable: false),
                    license_type_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_licenses", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_licenses_files_back_side_file_id",
                        column: x => x.back_side_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_licenses_files_front_side_file_id",
                        column: x => x.front_side_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_licenses_license_types_license_type_id",
                        column: x => x.license_type_id,
                        principalTable: "license_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_licenses_users_user_id",
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 28, DateTimeKind.Unspecified).AddTicks(4840), new TimeSpan(0, 7, 0, 0, 0))),
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
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d694c418-a06f-4fec-94c7-67e41862180a")),
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
                        principalColumn: "Id",
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
                    status = table.Column<int>(type: "integer", nullable: false),
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
                    cancelled_reason = table.Column<string>(type: "text", nullable: false),
                    complete_without_booker = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
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
                table: "SettingType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Default" },
                    { 1, "Trip" },
                    { 2, "Penalty" },
                    { 3, "RouteRoutine" },
                    { 4, "Pricing" }
                });

            migrationBuilder.InsertData(
                table: "affiliate_parties",
                columns: new[] { "Id", "code", "CreatedAt", "CreatedBy", "DeletedAt", "name", "status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("85c2c25f-7fdd-4a26-a4df-90b752b339b3"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("5e9bcc42-8e75-4918-acec-bd1d6159b77d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2365), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("7365eed5-69dc-4ca2-a907-94efd31686f1"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "id", "content", "status", "title", "type" },
                values: new object[,]
                {
                    { 1, "The process of finding drivers for your booking is done. Don't worry if there is not any trips without driver, we continue to find driver for you. A trip without driver will be refunded on 20:00 of the day before the trip occurs.", 1, "FINDING DRIVER IS DONE", 0 },
                    { 2, "Thanks for using our service, your booking is in the process of finding drivers.", 1, "BOOKING WAS PAID SUCCESSFULLY", 0 },
                    { 3, "There's not any suitable drivers for your next trip, sorry for this omission. We will refund for it.", 1, "NOT FOUND ANY DRIVERS FOR YOUR NEXT TRIP", 0 },
                    { 4, "Your driver has problem and he/she cannot come to pick you up, sorry for this omission. We will refund for it.", 1, "YOUR DRIVER HAS PROBLEM", 0 },
                    { 5, "Hot voucher is waiting for you. Use now lest miss it.", 1, "YOU HAVE A VOUCHER", 0 },
                    { 6, "Your driver is on the way to pick you up, get ready please.", 1, "DRIVER IS COMING", 0 },
                    { 7, "Have a nice trip. Wish you have a good experience in your trip.", 1, "TRIP BEGINS", 0 },
                    { 8, "You have arrived, see you again in a next trip. Thanks for using our service.", 1, "TRIP COMPLETED", 0 },
                    { 9, "You receive a new rating and feedback. Click for details.", 1, "NEW RATING AND FEEDBACK", 0 },
                    { 10, "Today, you have trip(s) to complete. Good luck.", 1, "DON'T FORGET TODAY TRIP", 0 },
                    { 11, "We have refunded for you successfully.", 1, "REFUND COMPLETE", 0 },
                    { 12, "Be careful with the rate of cancelled trip, you reach 80% of permission of cancelled trip rate.", 1, "BE CAUTIONS!!!", 0 },
                    { 13, "You reach the limit of permission of cannceled trip rate, you were banned now. Contact with our office for handling this problem.", 1, "YOU WERE BANNED!!!", 0 },
                    { 14, "You have new trip at this time, please check your schedule today.", 1, "NEW TRIP", 0 },
                    { 15, "You have received your earning for completed trip.", 1, "TRIP INCOME", 0 },
                    { 16, "You have received new report that need to processing.", 1, "NEW REPORT", 0 },
                    { 17, "Booker canceled your trips, don't worry we will find new trip for you.", 1, "BOOKER CANCEL YOUR TRIP", 0 },
                    { 18, "Hi {0}, We received your driver registration and we will reponse to you the result as soon as posible.", 1, "VIGO: Submit Registration Successfully.", 0 },
                    { 19, "Hi {0}, All your information was approved. Now verify your email to login into our system by click this link: {1}", 1, "VIGO: Final Step To Become Our Driver.", 0 },
                    { 20, "Hi {0}, In order to verify your mail, please click to this link: {1}", 1, "VIGO: Verify Your Email.", 0 },
                    { 21, "Hi {0}, some information of your driver registration was not correct so it was rejected. Please go to our office to support.", 1, "VIGO: Your Driver Registration Was Rejected.", 0 },
                    { 22, "Hi {0}, In order to verify your mail, please click to this link: {1}", 1, "VIGO: Verify Your Phone Number.", 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("e8ab5abe-d6e5-44e1-b835-e8e17ac51a04"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("a9861ae3-411e-495c-854a-8e2e2888d7c7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4662), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("abf9941c-5692-4329-9d61-f6235f574ef7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4671), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("3c2363ad-2d16-4788-8f00-8222dd112471"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("332c07b6-e7bb-4d25-93e5-004eabfcb2eb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("2ab0da36-4ec4-4d8a-b5b1-fb97a7365649"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4700), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("f2d5f135-cc88-4984-b69d-be8fcfb19041"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4717), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("ba94444f-5493-433d-8055-e4760cfbb86b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4726), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("51bf561d-3833-46cf-9f15-e257c8fd2cef"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("6041b950-0ac5-41dc-89c3-5f404cccf297"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4745), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("d7ffe61c-dfe3-4eef-a487-984103ca9e9c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("71e2457a-7bb1-400e-9466-05c7225dde67"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("7d84b1ba-14d3-4e5d-acfe-d29c62958cd2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, new Guid("521b9d2c-bc86-4b56-9405-df169af2e44e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 4, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4779), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, new Guid("4e3db70e-5327-45e3-8203-e8639b067f0f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 5, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, new Guid("87e0fe66-e180-4448-8b62-468712e792f6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 6, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, new Guid("2efef6f8-dd01-48e2-9363-4bd4a3a88195"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 7, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4811), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, new Guid("10138be0-9df6-40aa-86a1-10f2ea528ae2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 8, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, new Guid("dc9f6bc4-494f-4460-afc1-a47a0d821edf"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 9, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "license_types",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, new Guid("4fa84a68-2729-4ac7-8f75-eae71eebb160"), "Identification" },
                    { 2, new Guid("0b838360-f56e-464a-827a-78bad5ddb9fe"), "Driver License" },
                    { 3, new Guid("cc1f4727-c382-47f0-85d8-4372687eba94"), "Vehicle Registration Certificate" }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("3d3ece2a-12dc-4cfd-b1a1-79941db2fbd5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2476), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("a21db6a9-dbb3-4caf-83d5-45a0fa168015"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("0e7f226f-aecd-4e98-bf45-b9cc4518a4d2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2481), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("e3167339-8b46-4243-8542-ba776bb4e796"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2483), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                table: "setting_data_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "Default" },
                    { 1, "Integer" },
                    { 2, "Double" },
                    { 3, "Time" }
                });

            migrationBuilder.InsertData(
                table: "setting_data_units",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "Default" },
                    { 1, "Percent" },
                    { 2, "Minutes" },
                    { 3, "Hours" },
                    { 4, "Days" },
                    { 5, "Meters" },
                    { 6, "Turn" },
                    { 7, "Time" },
                    { 8, "MB" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("3c61e315-5ecd-461b-aa80-0550ba903259"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1413), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("02d15775-ecf8-4e8d-a592-7cfce3719961"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("726a11ae-a72a-4a20-81af-83658eb41c11"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4f6f250a-5986-434f-aa9c-4eea26e1f473"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df57c196-2b24-4022-b8a3-0fdce6928938"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a7139360-9d51-4894-b753-e49f1637a6cd"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c8093b0a-fff3-4d0f-81b7-8632b60e5e3d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1435), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("94f5305f-c56b-4f98-acc6-d4d5d9d76179"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("eaae5bad-03fd-41a3-9f39-d7299de91f36"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("61663cff-e354-48d6-9544-eeeab0dcb3f5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0abdaf22-948f-4632-87f1-a522ac8401fb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e9d4ac6c-4106-4ee4-a961-d6dbfe092554"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5647ef3e-e419-4c04-a8a4-2762f057a752"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("92fb7642-6997-4994-8cc8-e81a19cbcaf7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1460), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("75844560-d11f-4154-b7d1-2714d15e6b44"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("177fe9b8-a5c3-4f24-b0f1-afc72fb182db"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1464), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9232feab-0234-4105-88ba-baacbc326756"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1467), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2ea98d67-0750-48cc-a972-47d0ff40c926"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1470), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1c138009-6288-493a-b430-18352df2456e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1472), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e5a6cfe-ac5f-4be3-9fb8-89643573874b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1476), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fcb5c0aa-4323-4965-bf70-cc212dcef6fe"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("877e8ba5-7030-401b-968d-c6c2ebd290c6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1481), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("27a4a486-8d9c-421b-8c12-9dd5169b780d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d3b5584f-6172-4a1f-ba5a-af5d9907588b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("abc8ae45-b8a8-4ed2-850d-cfc62b7e387b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1490), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("90809666-13a7-45a1-8df6-9852ea434c01"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("56874b10-0e0f-467c-a46a-454fd9b17e56"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1496), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c583f6af-4f7e-45f2-b2d6-235a2ed85f0f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1499), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("042985eb-3102-49f8-9774-b3aee67a751e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("955b9928-88dd-4ee0-b4c1-8187494cdaa0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b363e86f-41be-4cce-bd1f-35601b0422a1"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0c5f87fe-b54b-4d54-a474-738c636b8568"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1513), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a7eb2fad-7d9a-417b-875d-f67edd5bbd48"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a962e592-2426-4a71-99ec-e3a3b994546f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbd1f59a-7c2c-46bb-8240-50b032a99418"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("99a4a77b-aefa-4260-9761-95d94adbbb97"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1525), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hòa, Dĩ An, Bình Dương", new Guid("bc8bfee4-0d50-49e6-af5f-0e64d40b5666"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a0ac428a-01ac-409b-93ac-6785b1ff695d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("acfe276e-f468-41b2-9e59-bc11dc366074"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9f2f473b-c423-46c6-93e2-45161c6b15f0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1534), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("27f33314-2d9b-4995-81db-d19d18641b54"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1536), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bd8c2f71-1566-49b6-99d1-59e50ca08415"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1538), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("638bba27-5b85-4b41-a39d-8f60a8b5ee10"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("17cfe0eb-2529-4e7d-8a7a-bdf311dfdb46"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1545), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9074b77f-6ddd-4331-9d06-8fa0894e6c01"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bd7c55c9-4044-4611-8260-cd7c0e240456"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d529dbc2-e35c-481f-b75b-b7ba4fa3d67e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1551), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b13fbacd-7d5c-41f8-9ed5-a1d49a47bc4d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3984ca55-94e9-4a49-9c22-24ebbf101a9b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("89072f52-c8c8-4a71-955d-d8b19a4cedcb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1558), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b6ea05c6-5edf-4cb0-b8fb-4bafb8e639d4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4b82e1a3-18fd-412f-ab98-0e2937c97d79"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b0420865-4bd8-45f5-8e5b-ebb3a1a54dc0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a85d5a94-9ac3-469e-a890-1ed32bd4b57b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1569), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ce62309-2e8d-420a-b2ea-a2c9f1d36eec"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8795eba2-2278-4e6b-9291-8deed64e9d72"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1574), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("da4f389c-b2d3-4a87-ae10-9d865303f08d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e6466f9-7b56-4263-999b-f0ae28c6f30e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1579), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c787892d-7da4-4a3d-a595-04296e687113"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1582), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b4210842-c557-483c-9190-b9ecded463f7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1585), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a5a0bcd-ed7d-453e-a56c-41f98bb65283"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b78c92eb-826c-4927-a6e8-60afaf8a6635"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c09ee1de-1d02-4107-b2b7-3b5de2fc6ad5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1591), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("22cb7d26-9faf-4c62-8baf-f454d5759572"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1593), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5a21699e-5409-43ee-88ac-7226491d45a4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e2a5538-f3b6-4d19-83fc-faad6905f6e5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1603), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ea873843-3ee2-4513-97a8-a616269877d2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1607), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("84fa4f75-ae85-4b5b-a9cd-77f686a6ac8b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1609), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29ac07df-7396-46df-9fea-3e2479b656bd"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("195bbab7-ea40-4435-9a42-1a2e0f5ee3b7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1613), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b895fd84-320b-44cd-ac57-9af5d4ece4f5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1615), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4dca9bd1-ad93-4fca-8984-f6f5a8a8f2af"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b1ecefab-e287-4d02-ac55-29bf580d799e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8b67dbe9-0c93-4938-9e57-77804f61ee3b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3bcc1474-3168-4427-8171-0242accc7dfb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6daa4c5e-8fe3-481c-8b88-28bec3bba300"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1628), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6e1df39-7965-406a-9b59-52f04ec2358a"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1e679f7a-3ce5-4662-804d-5335045f95e6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1f1cf492-b941-4fdd-a29c-6ebb6b4856e2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("017d963a-1b49-4653-a611-e3c42cb3cadd"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1637), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("086fb53e-259d-4abd-875a-16fb3f471d74"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("c6116b16-ae87-4b45-acf7-0c5e58236005"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1642), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("1bc1d5df-6744-421f-900d-6bac08c47ac9"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1646), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e7f4bd80-2440-4030-b3e7-549d0c58d1ce"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("43c87234-bc93-4a2b-af85-baf8399ec9fb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô K1-G3 Đường D1, Phường Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("770ff0fe-a2ea-451e-a0f4-96207f1be2a1"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("35ed33f8-63b8-4d58-a040-a21986095bc9"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4980), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4983), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4980), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("a01081ad-6476-4439-8953-395ee74f7e63"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4993), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4995), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("34a29d90-7f8e-4df1-b111-6335cea4b2f6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5005), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5007), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("091a51d0-901b-40db-b178-537a2b9a297e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5017), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 100", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("adb555e8-c612-4cc4-9bd7-dd03f3f52005"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5042), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5047), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 101", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("af2c4f07-f4d6-44cd-8b7b-b5e98eec90ab"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5060), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 102", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("ab84f97e-e45d-4211-b63a-e62f4f52c998"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5070), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5073), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 103", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("294359f2-8b34-461d-9bef-bd4289174c26"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5082), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 104", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5083), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("eb007162-de33-4d9f-98fe-cf397653cf93"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5101), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 105", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5097), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("0f383a7b-7016-4ca0-a142-2e6ceeb091c1"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5114), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 106", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("65b875b3-6bc3-4d63-a15e-4cf47dac0abc"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5127), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5131), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 107", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5128), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("10aaa683-fb70-4d38-bb5c-52cb4d3ceaea"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5141), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 108", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5141), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("b1c1b28d-de63-41ec-a67c-8fb5d75b9274"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5158), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 109", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("6b634921-34e1-40e5-b510-2c43e125310b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5168), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 110", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("4d40c87e-a164-42ec-b801-8ca5afb21e5c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5181), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5184), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 111", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5181), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("7db73f9f-d0bb-4c6c-b905-22feb9a70827"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5193), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5196), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 112", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("9109b0f6-8e16-42ea-a8f3-5a9f11a9bdb8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5206), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5211), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 113", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("25bd608b-bfdd-44d1-9cd2-ae722f237d18"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5221), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5224), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 114", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5221), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("ebaaf309-c871-4853-90cc-3ebd17c88c46"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 115", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5234), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("78f263ba-f28d-44d2-a736-1501cab03575"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5246), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 116", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5246), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("8708b287-54d3-4300-88c9-d955ec3b905f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5258), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5263), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 117", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5259), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("ab5f97a5-cdc7-4340-8364-75ade5e4d2ff"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5276), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5279), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 118", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("d5af94b4-0e7d-42fc-a4e5-660ae8bd507f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5289), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5292), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 119", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5289), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("4f9bfb50-61e5-4e64-b709-89ca5023ec71"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5301), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5304), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 120", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5302), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("146166af-6aa4-4847-85b1-235cae62fed6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5315), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 121", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5316), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("2927d582-e9bd-4e5c-b844-29cb161b5292"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5330), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5333), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 122", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5330), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("9d91f919-25f9-4a36-b0b4-97eea46a08a9"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5342), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5345), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 123", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5343), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("a9a9496b-3c41-4abd-8a28-2613cdfbc629"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5355), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5358), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 124", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("bd2f1788-bd0e-429d-9df2-48a57b4c378a"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5372), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 125", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("ad9f0c9a-8a1c-4e95-96a4-b6e8bd4e3942"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5385), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 126", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("a0612947-d226-46ac-bcfc-324e990ef547"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 127", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("fabdc00e-5f3c-4747-850f-3454ff73a552"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5411), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5415), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 128", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("ecb37ff1-429e-4140-8035-cbeb122096cf"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5424), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5429), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 129", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("b1a28f55-bcea-47d9-863c-9288ac353b69"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5439), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5442), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 130", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("3698e9a3-e6c3-4af1-87cc-2e95975bf571"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5451), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5454), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 131", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("c9480678-0702-49e3-b137-5e0b65d6d094"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5464), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5467), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 132", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("9489589d-d346-44f5-83b4-2e32dfcdf87d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 133", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("1b793e12-b652-4299-8509-ee32bc88720b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5491), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5494), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 134", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("505fa76f-ffe9-4d70-85ea-e1f5376dca84"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5507), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 135", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("3a1cc7b1-6812-4a58-8f95-c030ed4eabed"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5516), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5519), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 136", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5517), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("eed130c8-7d8b-443c-a023-96cd512f0371"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5534), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 137", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("22a3216a-58b3-491b-98fe-28657f85b936"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5547), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5551), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 138", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5548), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("62c476b6-62af-407e-b393-7379f6d97b42"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5561), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5564), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 139", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5561), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("813c0e48-8d0e-4f06-8e6a-c54e71cb342c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5576), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 140", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("ef349547-9209-497f-a3ba-dd0b99ab1145"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5586), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5591), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 141", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("9984523d-8d62-4cc6-855e-ea3318993497"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5602), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5605), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 142", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5602), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("be3c7811-f623-47ee-b538-d39ba625d91d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5614), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 143", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5615), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("6a8b9e16-052a-460a-b785-5fb609adf0f7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5627), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 144", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("491919fc-0520-4cc1-ad3f-10b6d0edaaf6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5644), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 145", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("1664e6c3-7ab7-4565-bcb5-c6035c2f1907"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 146", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("85f4cb42-24c0-446d-918b-7be3d59a05d7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 147", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("10add78e-4af9-4d7f-971e-89dede136b2d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5683), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 148", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("a6863438-b949-457a-b772-30949d5e4056"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5696), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5701), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 149", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5696), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("a87a1b07-4ede-4039-8eee-48c1fb5779fe"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5714), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 150", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("e4819989-b1e8-4fec-9e0c-462267b9dc1f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5724), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 151", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5724), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("c5d05fdc-6f47-4b51-b782-2d76c66f9bba"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5736), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5739), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 152", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("3108668e-c0ae-4b10-a626-015c080c9b9b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5750), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 153", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("888d9f42-8c10-4fd2-82cf-f18620660d9e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5765), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5768), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 154", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("66cd9abf-d1ed-4b89-8637-447a5682b006"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5777), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5780), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 155", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("96d65d1e-4f4e-49d9-ad17-2a9a6e60a76c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5793), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 156", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("8bed61b5-1a52-4d79-9784-c64810408c9c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5806), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5810), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 157", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("be4ee29e-4a12-45ac-bfcc-877b410e4bd7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5826), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 158", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("f4c0434b-54b3-4cb7-b06e-f4da86e64ae8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5836), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5839), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 159", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5837), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("15db2157-5b03-49af-b988-0482525ce193"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5849), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5852), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 160", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("6d23a263-2df1-444e-a3e5-16b6b7764d9f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5861), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 161", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5862), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("f0ce73fb-e8c6-409b-8e25-81059c159b9d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5876), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5879), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 162", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("93076a36-00b4-4ad5-9a78-ad743d77916f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5889), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5892), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 163", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5889), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("6df7c6c9-0f1b-4c84-b950-e18209fa2b8d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5902), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5905), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 164", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("ce364758-9d39-4edd-9f09-bf318c3a105e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5914), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5919), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 165", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("79a60556-1924-4f6a-979a-ad554c38c369"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5929), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5932), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 166", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5929), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("37cc5c01-b36b-419d-abec-867e006f5839"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5942), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 167", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("cf86816d-9e56-4492-ab7a-78839b8fb570"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5957), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 168", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("d3353055-5ef5-42d1-974f-3383ab2fe3c5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5971), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5976), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 169", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5971), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("712b29a1-373f-4d6c-917c-a82f71854ae2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5989), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 170", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("0fe70512-dd1d-400f-a364-e6a215d0e1fe"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5999), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 171", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(5999), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("4a674951-bc6b-4dd3-8cea-4851409e192a"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6011), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 172", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6012), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("ea587d63-d2c6-4bd0-ac9b-1362a1ae5b28"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6024), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6029), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 173", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("ee7ef05d-818f-4232-ab0f-e206b3951767"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 174", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("c4b98588-a864-42f4-a7c7-28dfb1540e3e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6051), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6054), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 175", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("d7a24d00-e431-4592-ba9c-817fca5ea01f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6064), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6067), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 176", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6064), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("5d0f901b-fcf1-4b9b-aee6-32390c73ea0b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6076), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6081), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 177", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("83eadcaf-e9c7-4af9-ad9b-6168632935e7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6091), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 178", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6092), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("78e22bcf-efe8-4c87-b3ed-e94f42d2656b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6104), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6107), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 179", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6104), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("67ff0b80-1315-4d20-bf9e-b8cad6927dea"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6124), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 180", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("17d72ef2-1db8-40b5-a115-d3b77da52439"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6133), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6138), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 181", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("49f7abbc-948e-4ec4-ad5f-e4f6344a2634"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6148), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6151), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 182", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6148), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("911c7f1b-9ef7-4a0b-a140-6478ba8f3d6d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6164), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 183", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("8194a4bb-4112-4802-ac51-ee7aa83ab0d0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6173), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6176), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 184", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("27a8dd39-6812-438d-9096-655134d64616"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6186), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 185", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("12ba67d0-54a7-4713-a891-74ac9c6414c6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6203), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 186", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("77b0e464-3ac3-499b-8d31-d431d95071c7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6213), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6216), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 187", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("01a0bd94-f547-4c0a-9bf4-59f81723e095"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6225), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 188", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("6379bffa-5109-4457-9e0d-6f8927307f84"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6238), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 189", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("e9d0ebf3-6039-4ce6-beea-c28d0be60320"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6252), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6255), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 190", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("c98d4816-391d-4603-bf3e-a0585e393210"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6268), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6271), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 191", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6269), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("db211db7-4c78-4583-9ca6-775c31627055"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6281), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 192", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6282), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("60934617-c7c0-4ead-b763-5d5f2fea4d96"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6294), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 193", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6294), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("d0774c4a-4ff9-4847-a77f-09aa2ca4afef"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6311), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 194", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("af805510-9b7d-45ed-a964-eafe358d7ef4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6321), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6324), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 195", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6322), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("46dc1a98-fff7-4c54-ba2e-f43f38105750"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6334), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6337), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 196", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6334), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("212860fc-7db6-42fa-962f-2bb99ada25c2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6346), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6351), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 197", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6347), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("a5aebf6c-6d86-482d-960f-a504449da1cc"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6364), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 198", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("f82ff9c5-4bde-409f-b4ea-230c2b3e2c30"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6374), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 199", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6374), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("ed195c56-6edd-4f19-91a7-09badc95059f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6388), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("d9c38b89-2642-4da1-a5c6-65a6f140e0ee"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("ad6f4a3d-462f-4c00-a80f-3f6df1f5064e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("fe58958e-3612-450d-94ea-9e4c3b5c7dab"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("25f4f553-0b45-4b1a-96bb-c6113bf4c8e8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("c6246c77-bd0a-4c86-b4fa-ef9d4b559423"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("33e1ca0d-7836-4427-8938-2e6e0d9a3194"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("929065b3-15bc-42b0-9b36-6acfc386a83e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6476), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("21f48650-9623-40ea-9a6e-3bc60ee2e490"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6487), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("1700994b-1404-460b-b76b-2677e419df9c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("f97824cf-92a5-4eb4-a94e-d3aa57199325"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("38550f61-2919-4e86-92e6-d9794db449a0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6521), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("21ab813c-99b1-4e6c-a561-971534667fa9"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6535), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("3b4592aa-c894-49d1-9344-8c024b03e767"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6547), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("0bb5be38-5953-43b0-aa47-9e9578324a29"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("a15c7ed8-6301-4bb1-b011-fc16748ade45"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("ac1c3351-cdbe-4e17-a179-da53d4491353"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6582), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("e174b3ef-aac8-456b-ae20-9d8c55e7024c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6595), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("c02a5ae5-bb30-4df8-ba1b-f580de7b4be8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6608), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("33e2c447-f167-49f5-b997-5079b0f85ded"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6619), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("43e70123-3589-436a-be6d-d94538a8ce90"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("9ac741ac-64a9-4c6d-869b-c59830d394e7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6645), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("c3803170-fe00-40ee-b6d7-0263b68aa4e5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6659), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("4507e8f2-e8de-46cc-94b4-0a332d6155b6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6670), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("af63c096-1a13-46a7-b23d-3346154155c8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("9fa97c57-547e-40ea-9e37-10ade7816f8c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6691), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("df84f118-d132-4069-837b-342c15559889"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("d4aa9e24-ee52-4c59-80f8-71cbc7eabc40"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("f7907671-d9d9-4071-8e36-59ca2deb5f46"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6726), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("902dbda7-cc64-494b-b82e-234c03bd0446"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("6e60d110-7543-40fb-8d8e-d49ac716ab9a"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("f40dd75e-7c3e-4534-9412-d0717e35228c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6766), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("926c833a-0c93-4922-98fd-160b4a7fca37"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("fd753382-17b5-48a1-bb3c-dae8c7a69d7f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("4797c388-8c04-4201-ab02-1bb89aaca100"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6801), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("fa1f948c-14e9-4516-bfa3-de0afdb19623"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("00d4ad22-8210-4a17-87c3-371392682197"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("c8ddd15c-268a-4c0b-9df5-4d59c825827c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6834), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("7d5ef3b5-e732-4c3e-8440-f6052e86d680"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("99a8a96d-a317-4f80-8c45-3717bb2cf084"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6857), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("b78efa42-bda9-479e-bf6a-e2abb44bf2ed"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6868), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("46d8d341-d488-4f10-a9d5-5e9c1d873bb7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6879), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("208225d5-b905-41ca-be26-295179017534"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("a3c3037e-f168-4d16-8235-c4be5cd77727"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6907), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("1a1d4598-3e74-471c-b8ec-8103a4711d80"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("1a4a6514-7677-4b67-8bd6-1cdcb3a09a19"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("0fd19625-ed88-4473-b181-92e5eeb77cd4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("cd58a837-c21d-4c69-9699-5253ebf90c8d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("911a9e90-1132-437d-9bb7-b976ab669b56"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("b1d46580-e2bc-4820-9b9d-e558b4e68d58"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("a04edff4-f4d6-42f1-a504-5a453466efb2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6988), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("1496d045-5010-4ecb-8023-c79ac9bd365e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(6998), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("7ba2e95c-da8f-494b-863e-697e3803c2ec"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7013), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("4b00be67-5dd1-4673-9929-b9679c46676e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("08a60d29-a309-405b-9624-c9b605cc52fb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("e43ce4d9-0897-4536-8c72-55fbdbb8fd2d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("a8e79afc-754a-4fcf-92f3-5255cff527d0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7059), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("0258dc99-8c11-457f-b244-677724065de4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("cd8950df-e20a-445c-851a-e2fba51bf71d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7083), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("233c83c2-07f7-4105-b845-1fc9e3756d7a"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("fda07436-4dbd-439a-b2df-2f25d823165f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("a403b8e6-7678-44ff-8065-50661953cdf0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7116), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("3abf1e09-9031-4c69-866c-641e00cae71a"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("63fcc5e5-b112-4e2f-ba18-d94b22d66b19"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("e496d839-86c4-4971-b964-1b10da3e752b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7156), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("d5ae37b1-7dd8-462e-b2ce-5af8d1b1d931"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("6b60f44a-6d9d-4c78-ac19-5e39173eef6f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7181), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("d903a77c-f828-4f0d-9d1a-05f1919abd6b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7192), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("964dac77-c445-4fc9-8ca5-3b49c9a11ba4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7203), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("771137c7-c791-47ec-9c27-058ab9aaa2b8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("a376b792-97bd-46ee-aa66-88f048774716"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7227), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("cfb5ad9b-5950-4e5c-9be8-31fc201f5968"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("c229a224-2fc5-4ebe-bf7f-2c20b7808105"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("045d91ba-1862-4df0-9c07-76ea2a8ca25e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7260), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("fc78a3ad-9521-4a59-8a81-466a1d4b15a2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7276), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("814c3540-849d-4139-b657-9d8c73fc7e70"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("478b893e-1106-46d7-95d2-b8bdcb283e8e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("5fb5b96c-de05-4724-a092-55e9def5f96f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("513abfec-7e7f-4ae4-8906-f8973feacefd"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7322), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("41abdffc-9511-4e6c-b993-0b612c8e86fb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("78cade75-fa6f-47ea-92b0-4c35a902493f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7344), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("fe7ce7ac-ade2-4927-beed-43ef41c2506c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("a28564f2-09b8-411a-82d4-9b9de224b28e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("2140287b-6ede-464b-b386-41f168f459b1"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7379), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("610db3bf-35bb-4d6a-9d38-fee182ad76f8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7392), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("bf47c48a-f63f-4b3b-ba6d-7b671e24574b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7407), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("a74ebf77-95de-4b23-a399-e9b12035f34c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7421), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("ea82d99c-a80d-4848-916f-dff4e3b19828"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("da2d145d-9fd5-4455-9491-388d9045813e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("9d35d5e7-5f34-4eeb-a20a-107394cb13b5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7453), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("b8c691f6-7d10-487e-930f-711c3201008f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7466), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("f5b7abf6-281f-42e5-a998-a3da19d57e7b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("e795f686-0a5d-44fd-a603-b4fdb53a01bd"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("79bf0841-dc83-4803-9b42-c75a25ad6088"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7498), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("02eac950-82fd-490f-ad8d-509349231dd5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("65127373-07d9-4418-90d6-924c17a2b692"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7526), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("7cb1ebd8-0866-49cb-a021-9c75afc23351"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("e28ae543-1448-459b-aaea-db7b327bbc01"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7548), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("61c57775-ee1c-4414-bc62-c69f30e2f74e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("c9b3f3a4-2abf-4cd0-a452-7a0a39a348bc"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7572), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "name", "slot", "status", "type" },
                values: new object[,]
                {
                    { 1, new Guid("9548db52-65ac-45e6-8578-fa3179ab8438"), "ViRide", 2, 1, 0 },
                    { 2, new Guid("60a11fca-45a7-4622-998a-0eff86262653"), "ViCar-4", 4, 1, 1 },
                    { 3, new Guid("ba41bb8e-d827-47d0-966f-0c7905130e71"), "ViCar-7", 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[] { 9, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2410), new TimeSpan(0, 7, 0, 0, 0)), 0, null });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7726), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7733), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7747), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7754), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7761), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7769), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7784), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7794), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7803), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7811), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7819), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7834), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7842), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7851), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7872), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7880), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7888), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7896), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7904), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7919), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7943), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7950), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7966), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7973), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7981), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7989), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7997), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8005), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8012), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8020), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8027), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8048), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8056), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8064), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8072), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8079), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8087), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8095), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8113), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8121), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8137), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8153), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8160), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8168), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8176), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8184), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8191), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8203), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8219), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8227), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8235), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8243), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8251), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8258), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8266), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8282), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8290), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8297), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8305), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8321), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8329), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8337), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8345), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8353), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8360), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8368), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8379), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8388), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8395), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8403), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8411), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8427), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8435), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8443), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8451), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8458), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8466), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8490), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8497), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8521), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8529), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8537), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8545), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8556), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8564), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8596), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8604), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8611), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8624), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8639), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8653), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8667), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8681), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8695), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8722), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8735), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8755), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8769), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8783), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8795), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8803), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8811), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8827), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8834), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8842), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8856), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8864), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8872), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8879), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8887), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8895), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8917), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8959), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8967), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8974), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8982), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8989), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(8997), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9012), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9020), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9027), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9035), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9057), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9064), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9072), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9079), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9087), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9102), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9128), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9136), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9143), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9151), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9158), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9166), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9181), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9189), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9196), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9211), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9234), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9242), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9249), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9257), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9264), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9272), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9280), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9293), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9301), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9309), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9317), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9324), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9340), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9347), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9355), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9363), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9370), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9378), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9386), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9393), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9401), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9409), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9417), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9424), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9432), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9440), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9448), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9457), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9478), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9487), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9494), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9502), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9510), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9533), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9541), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9572), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9580), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9588), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9595), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9603), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9618), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9626), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9645), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9654), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9662), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9678), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9685), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9693), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9701), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9709), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9728), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9740), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9748), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9756), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9764), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9771), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9779), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9787), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9794), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9810), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9818), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9825), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9833), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9841), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9849), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9864), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9872), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9888), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9903), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9915), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9923), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9931), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9962), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9970), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9978), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9985), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(9993), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(8), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(8), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(16), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(16), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(23), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(24), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(31), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(39), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(39), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(47), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(47), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(54), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(55), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(62), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(63), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(70), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(70), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(78), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(88), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(89), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(97), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(97), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(105), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(113), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(121), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(128), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(136), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(159), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(167), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(174), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(182), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(190), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(205), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(213), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(229), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(255), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(270), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(297), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(316), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(324), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(332), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(340), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(347), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(355), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(362), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(370), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(377), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(385), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(400), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(415), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(422), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(430), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(445), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(453), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(460), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(468), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(475), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(487), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(495), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(502), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(510), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(532), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(540), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(547), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(555), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(570), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(585), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(592), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(600), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(607), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(615), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(622), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(630), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(638), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(645), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(658), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(666), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(674), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(688), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(696), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(704), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(711), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(719), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(726), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(733), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(741), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(756), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(771), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(779), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(786), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(794), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(801), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(808), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(816), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(836), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(844), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(851), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(859), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(866), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(897), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(904), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(912), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(919), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(927), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(935), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(942), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(950), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(957), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(965), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(980), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(987), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1006), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1014), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1029), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1037), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1052), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1067), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1687), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1689), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1760), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1763), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1765), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_type_id" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1263), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1280), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1296), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1085), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1129), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "settings",
                columns: new[] { "id", "data_type_id", "data_unit_id", "key", "type_id", "value" },
                values: new object[,]
                {
                    { 0, 1, 2, "AllowedMappingTimeRange", 0, "3" },
                    { 1, 1, 2, "TimeBeforePickingUp", 1, "10" },
                    { 2, 1, 2, "TimeAfterComplete", 1, "3" },
                    { 3, 2, 1, "TradeDiscount", 4, "0.2" },
                    { 4, 1, 0, "DefaultPageSize", 0, "5" },
                    { 5, 1, 3, "TimeRatingAfterComplete", 1, "24" },
                    { 6, 3, 7, "CheckingMappingStatusTime", 1, "20:00:00" },
                    { 7, 3, 7, "NotifyTripInDayTime", 1, "06:00:00" },
                    { 8, 3, 7, "AllowedDriverCancelTripTime", 1, "19:45:00" },
                    { 9, 1, 6, "TotalTripsCalculateRating", 1, "100" },
                    { 11, 2, 1, "MaxCancelledTripRate", 2, "0.1" },
                    { 12, 2, 1, "NotifiedCancelledTripRate", 2, "0.08" },
                    { 13, 1, 2, "TimeSpanRounded", 0, "5" },
                    { 14, 1, 2, "TimeSpanBufferToCreateRoutine", 0, "5" },
                    { 15, 3, 7, "TimeToCreateTomorrowRoutine", 3, "20:00:00" },
                    { 16, 1, 5, "RadiusNearbyStation", 1, "6000" },
                    { 17, 1, 5, "RadiusToComplete", 1, "100" },
                    { 18, 1, 4, "LastDayNumberForNextMonthRoutine", 3, "7" },
                    { 19, 2, 1, "DiscountPerEachSharingCase", 4, "0.1" },
                    { 20, 2, 1, "ThresholdDiscountPerEachSharingCase", 4, "0.5" },
                    { 21, 2, 1, "AllowedCancelAfterCreateBookingTime", 1, "30" },
                    { 22, 3, 7, "AllowedBookerCancelTripTime", 1, "19:45:00" },
                    { 23, 2, 1, "TradeDisountForBookerCancelTrip", 4, "0.1" },
                    { 24, 1, 8, "DriverRegistrationFileSizeLimit", 0, "20" },
                    { 25, 1, 8, "BannerFileSizeLimit", 0, "20" },
                    { 26, 1, 8, "PromotionFileSizeLimit", 0, "20" },
                    { 27, 1, 2, "TimeBeforeStartTrip", 1, "30" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("45690abd-bd17-4ae5-8cf9-7356d8d93dfb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4854), new TimeSpan(0, 7, 0, 0, 0)), null, null, 1, 1, "Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("7789bf2a-f352-4703-8f91-9d5c18e65b36"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4874), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4878), new TimeSpan(0, 7, 0, 0, 0)), null, null, 2, 1, "Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("a0d775f7-51c2-43c4-b2b2-6d1beb20b194"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4889), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4891), new TimeSpan(0, 7, 0, 0, 0)), null, null, 3, 1, "Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4889), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("a8b705ec-a9b0-4eaf-a095-ca9ee826542c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4901), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 7, 0, 0, 0)), null, null, 4, 1, "Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("ccfe85e3-6117-496d-96f4-016db566ce3b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4915), new TimeSpan(0, 7, 0, 0, 0)), null, null, 5, 1, "Loi Quach", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("7f5f18f5-21df-49b5-89cd-11023654c6e6"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4926), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4930), new TimeSpan(0, 7, 0, 0, 0)), null, null, 6, 1, "Dat Do", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("f7cb8a2c-ec19-42f1-955d-d9e77aaa3612"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4940), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4942), new TimeSpan(0, 7, 0, 0, 0)), null, null, 7, 1, "Khoa Nguyen", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("9dffb281-b3c0-4fb5-83db-f247d71441e2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4954), new TimeSpan(0, 7, 0, 0, 0)), null, null, 8, 1, "Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("fdd5bba5-fe81-45bc-aa82-5ffc5230e6b2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4967), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4968), new TimeSpan(0, 7, 0, 0, 0)), null, null, 13, 1, "Admin Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(4967), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("297b59e0-6e0c-49c0-8c71-7ce871c97f0c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1947), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 2 },
                    { 401, new Guid("96437808-152d-43af-b9aa-814890f8793f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1956), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 2 },
                    { 402, new Guid("62354b38-12c7-4932-bcd0-7fe590c4bdd9"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 2 },
                    { 403, new Guid("c3c12f21-73ad-4ee6-9df5-eee0219816e4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1964), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 2 },
                    { 404, new Guid("4a82cdbe-d3cb-4be6-bdf0-6260bd5589fa"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1967), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 2 },
                    { 405, new Guid("54818d38-0a65-4d8d-8671-f9198b2b5436"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1971), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 2 },
                    { 406, new Guid("afd5f6c1-bec5-4650-90fe-5f11b45d25df"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1974), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 2 },
                    { 407, new Guid("b1538551-57ac-46fa-ae60-9e51db82dac7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1977), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 2 },
                    { 408, new Guid("89862c3c-03db-4729-9022-790cdeef3df8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1980), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 2 },
                    { 409, new Guid("4cc63871-66a7-4749-a905-4d71d1a8fbb9"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1982), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 2 },
                    { 410, new Guid("dcc57d06-6272-4fe1-81a3-51ba5f9ce4e8"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1986), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 2 },
                    { 411, new Guid("862d2b1d-5084-41ab-b728-60ba99ee53b5"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1991), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 2 },
                    { 412, new Guid("c3a2e29b-b43d-4609-9ba4-c1f8324350a1"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1994), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 2 },
                    { 413, new Guid("da806a55-5753-4529-85a5-bf9d20e651b0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 2 },
                    { 414, new Guid("0b4e5fd0-2116-4846-8711-684b2611800a"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2004), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 2 },
                    { 415, new Guid("6e0a51c0-e65c-4278-a54b-399c636aae5d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2008), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 2 },
                    { 416, new Guid("1d2724f5-1afe-4435-8c11-eff57f43f81c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2011), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 2 },
                    { 417, new Guid("f484e496-bc15-480e-8e26-bef71c600c45"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 2 },
                    { 418, new Guid("ec133cb0-f000-456d-a5b2-24cb08c99078"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2017), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 2 },
                    { 419, new Guid("7d3fb193-e892-49ef-9a04-1ae94e5b924c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2022), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 2 },
                    { 420, new Guid("5d0e5df4-55f3-4463-b6f9-cd0e55a89ce9"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2025), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 2 },
                    { 421, new Guid("03012499-eda9-48a3-8664-09ebf289428b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2028), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 2 },
                    { 422, new Guid("ae70f273-ed35-4c2c-b58b-4863c106cc40"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2031), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 2 },
                    { 423, new Guid("3ae3f9a1-de12-42d1-abb6-0a92adbe8f8e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2034), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 2 },
                    { 424, new Guid("27618786-992d-40de-b6e9-dca9a47ebaeb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2036), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 2 },
                    { 425, new Guid("162a9f5a-8046-49cc-9b1d-1d34dabafe48"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2039), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 2 },
                    { 426, new Guid("8f3f921a-e77e-4742-aad7-3ae4d4456ecd"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2042), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 2 },
                    { 427, new Guid("7fdbd886-e91e-426f-827d-eaee8f9a95a1"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2047), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 2 },
                    { 428, new Guid("7de42099-07ed-494b-9006-78a8e7367b9b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2050), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 2 },
                    { 429, new Guid("bf128d23-9db6-491b-9db0-8a38b05fb18c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2054), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 2 },
                    { 430, new Guid("3e21138e-b3a0-4ca8-8f7c-1ec59dbc70f4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2057), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 2 },
                    { 431, new Guid("854e3ef5-181f-4e44-b6e0-dc21d1cf3700"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2060), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 2 },
                    { 432, new Guid("952a569c-7251-4ddc-b8ad-be3aafaa56f4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2063), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 2 },
                    { 433, new Guid("9ca7bc23-420c-40cd-ba90-890747da9baa"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2067), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 2 },
                    { 434, new Guid("91a3e8bc-f6f2-4726-96d4-c2204bc4fcf4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2069), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 2 },
                    { 435, new Guid("7e260119-8af4-44a2-9379-ddcf2d0350c2"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2074), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 2 },
                    { 436, new Guid("d2269f03-67ee-4cb0-b6c0-c0f39deee692"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2077), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 2 },
                    { 437, new Guid("6243ede3-f481-4fee-8fe2-f4a604f8adcf"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2080), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 2 },
                    { 438, new Guid("f01f2543-fb50-4ef9-bf2a-f2fde86324dd"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2083), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 2 },
                    { 439, new Guid("2841b2a0-1cfb-4c72-b2fc-0af9334aca23"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2086), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 2 },
                    { 440, new Guid("dde8c7c1-76b4-4469-975f-5e9c9fe32010"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2089), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 2 },
                    { 441, new Guid("a54b1cf7-de45-4109-867c-ed318ebead12"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2092), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 2 },
                    { 442, new Guid("70a893e4-b1a3-4914-8490-277871b9ed25"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2095), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 2 },
                    { 443, new Guid("745430d2-5401-4316-8f76-75fe48f779ab"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2100), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 2 },
                    { 444, new Guid("7533982c-06e8-4362-acf4-da099662f8f9"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2103), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 2 },
                    { 445, new Guid("7891b209-02c5-4542-91e4-98c1ce21a1d0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2106), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 2 },
                    { 446, new Guid("daab49a5-dd81-40cc-9136-3dbce986f429"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2113), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 2 },
                    { 447, new Guid("5970f619-524c-4a05-b48c-4487fde3a243"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2116), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 2 },
                    { 448, new Guid("98739e37-bc7b-49b4-8b49-b0af0ba7510e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 2 },
                    { 449, new Guid("cbeedf3e-f1c7-4145-908a-3f8e77650d01"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2122), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 2 },
                    { 450, new Guid("526f1d0e-b53b-463b-b7be-e49ccb4804ca"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2125), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 2 },
                    { 451, new Guid("de27753f-2f92-4222-87e1-da5ada8da646"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2130), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 2 },
                    { 452, new Guid("263f4f41-55fd-46c8-bfb2-98fac3d3b3ea"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 2 },
                    { 453, new Guid("bee0e29e-6237-4536-b4dc-722a0063b49c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2136), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 2 },
                    { 454, new Guid("26aa7f7a-56ae-4502-95df-02de2cd3d308"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2139), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 2 },
                    { 455, new Guid("5423884a-228a-41ea-baed-2be2d175ec22"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 2 },
                    { 456, new Guid("b9a3d7a0-0f32-4ad5-8ded-1e78f7458f93"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 2 },
                    { 457, new Guid("e75b18d6-8eb4-45df-bcbd-5d08b6b0d2ba"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2148), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 2 },
                    { 458, new Guid("23279485-0a0a-42fe-8a3f-196714667451"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2151), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 2 },
                    { 459, new Guid("0564a88f-b2b8-4f12-8dd1-2a03da36935d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2156), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 2 },
                    { 460, new Guid("6cefdab4-8fca-445a-bb79-fe82bfed7f24"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2159), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 2 },
                    { 461, new Guid("eb54f168-2e02-419d-b65b-d9f018988132"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2163), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 2 },
                    { 462, new Guid("b1d17733-3ad1-4509-8c74-23f96a8f1b46"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 2 },
                    { 463, new Guid("ba5c5de8-2435-4782-972b-81cbe362674f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2169), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 2 },
                    { 464, new Guid("5e033daf-a7db-4dd6-85c8-98d5efa1bbd0"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2172), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 2 },
                    { 465, new Guid("80301ff8-4b9e-4eee-a3be-73a9cffa2901"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2175), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 2 },
                    { 466, new Guid("b7762d5d-2b76-42a3-9629-c83503625d9c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2178), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 2 },
                    { 467, new Guid("499ae85e-9b59-4a1d-a3e8-234430de7234"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2182), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 2 },
                    { 468, new Guid("36f7f4d4-ca7c-4e66-a93e-800e2b82c104"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2185), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 2 },
                    { 469, new Guid("e0750b07-170a-472c-b744-f61ec9bcf3eb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2188), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 2 },
                    { 470, new Guid("fadde388-60a4-4077-8809-1180e5bae96c"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2191), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 2 },
                    { 471, new Guid("d0d8d1a4-b506-4041-87be-ceaa3929438b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2194), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 2 },
                    { 472, new Guid("0e5327cf-c3bc-4ffd-a525-dd3aa890c1dc"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 2 },
                    { 473, new Guid("6676f9ed-bcf0-49b6-8f69-cc653cdbd35f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 2 },
                    { 474, new Guid("7430ccc5-34fa-4190-840a-c7cc4a56d02b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2203), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 2 },
                    { 475, new Guid("2f99c40a-6c33-4aa5-bea3-af9041a07037"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2208), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 2 },
                    { 476, new Guid("666f787a-a63e-4792-b952-232519880654"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2215), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 2 },
                    { 477, new Guid("7c9d6dca-6a3d-4901-b9b3-1c23384c45b4"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2218), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 2 },
                    { 478, new Guid("0e513d20-b730-482c-a7d8-1f4533163777"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2221), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 2 },
                    { 479, new Guid("07a178b4-15ca-430c-9d14-00a56fc23137"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2224), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 2 },
                    { 480, new Guid("309b4bf3-a33f-48bd-aaad-c7008cadd806"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2227), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 2 },
                    { 481, new Guid("fb980d35-6b83-4286-b5a6-d55643dbcef7"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 2 },
                    { 482, new Guid("146883fe-018f-4a73-b42f-39457f00b975"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2233), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 2 },
                    { 483, new Guid("f1bde600-c8fc-4fba-b08c-52bd0e2d1117"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 2 },
                    { 484, new Guid("55899e23-2fd9-44be-bb0a-6f1371eaa5a1"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2241), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 2 },
                    { 485, new Guid("57299a86-1815-4eab-98ff-2c8eb3268a29"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2244), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 2 },
                    { 486, new Guid("863cb031-3f13-4cc1-bf14-04c9ad528b3a"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 2 },
                    { 487, new Guid("32e9cec7-d229-467a-9fc5-3742cdfacb7e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 2 },
                    { 488, new Guid("a4f15952-e2a6-42d5-ac94-f34fa885516e"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 2 },
                    { 489, new Guid("d0303e20-52ff-4096-b9b2-03dea66b948b"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2256), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 2 },
                    { 490, new Guid("e08f5f51-49c0-473b-9679-3a34792c8e53"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 2 },
                    { 491, new Guid("265e25d8-12f6-4109-baee-831a06ec94cb"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2263), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 2 },
                    { 492, new Guid("39604b17-5939-410e-8caa-f12d0f75f2ea"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2266), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 2 },
                    { 493, new Guid("c1c180e2-0c15-4213-b16d-a5f5f02d5d5f"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 2 },
                    { 494, new Guid("289bffab-07dd-4e4a-a7cd-169f284b0c38"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2272), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 2 },
                    { 495, new Guid("c5df45ea-a163-427d-ae44-3540da190943"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2275), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 2 },
                    { 496, new Guid("067d7d2a-a766-4bf8-9dd6-94d7ef2eed15"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2278), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 2 },
                    { 497, new Guid("7f3112e8-8690-40e2-b771-45828c3a601d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 2 },
                    { 498, new Guid("f39937d8-b3d5-473b-874d-3f0a9c259abe"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 2 },
                    { 499, new Guid("665a8bd6-5ac4-4e36-9f52-a1d629a09536"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 2 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7588), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7606), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7612), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7619), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7635), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7642), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7649), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7657), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7665), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7672), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7679), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7686), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7696), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7703), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7710), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 49, DateTimeKind.Unspecified).AddTicks(7719), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1834), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1847), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1862), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1890), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1904), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1149), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1243), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1320), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1343), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1360), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1374), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1387), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "user_licenses",
                columns: new[] { "id", "back_side_file_id", "code", "created_at", "created_by", "deleted_at", "front_side_file_id", "license_type_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 15, "2d6adbbd-9258-4433-9c0c-b52388f17d28", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(3073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 14, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(3075), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 17, "9bfec823-d9f1-4de0-bea2-92c36777ffe6", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(3095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 16, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(3096), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, 19, "4711e2b8-cf98-44ae-8dde-654c3f6c579a", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(3106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 18, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(3106), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("0cc0d4ff-9602-4226-84cc-bf4da823d84d"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1937), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("54ea629c-2d3d-463a-8678-01f9be222e15"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1940), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("0cc61923-6dff-487a-b4ed-1733c8064f28"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1943), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("3ae4ffb1-bd75-4fee-860c-8d0e968737de"), new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(1945), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2394), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2399), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2401), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 13, 41, 9, 50, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
                name: "IX_affiliate_parties_Id",
                table: "affiliate_parties",
                column: "Id",
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
                name: "IX_license_types_code",
                table: "license_types",
                column: "code",
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
                name: "IX_promotion_conditions_vehicle_type_id",
                table: "promotion_conditions",
                column: "vehicle_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_promotion_users_promotion_id_user_id",
                table: "promotion_users",
                columns: new[] { "promotion_id", "user_id" },
                unique: true);

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
                name: "IX_reports_code",
                table: "reports",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reports_user_id",
                table: "reports",
                column: "user_id");

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
                name: "IX_settings_data_type_id",
                table: "settings",
                column: "data_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_settings_data_unit_id",
                table: "settings",
                column: "data_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_settings_key",
                table: "settings",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_settings_type_id",
                table: "settings",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_stations_code",
                table: "stations",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_back_side_file_id",
                table: "user_licenses",
                column: "back_side_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_code",
                table: "user_licenses",
                column: "code",
                unique: true,
                filter: "license_type_id = 3");

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_front_side_file_id",
                table: "user_licenses",
                column: "front_side_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_license_type_id",
                table: "user_licenses",
                column: "license_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_user_id",
                table: "user_licenses",
                column: "user_id");

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
                name: "IX_vehicles_license_plate",
                table: "vehicles",
                column: "license_plate",
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
                name: "promotion_conditions");

            migrationBuilder.DropTable(
                name: "promotion_users");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "user_licenses");

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
                name: "setting_data_types");

            migrationBuilder.DropTable(
                name: "setting_data_units");

            migrationBuilder.DropTable(
                name: "SettingType");

            migrationBuilder.DropTable(
                name: "license_types");

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
