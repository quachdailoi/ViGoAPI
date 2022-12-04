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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("bb787ea1-86d8-472e-b087-6712877f996e")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 342, DateTimeKind.Unspecified).AddTicks(3765), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("ae1b9c57-41c6-4048-9755-0d03ce1fdd25")),
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
                    { 1, new Guid("9585c347-266d-4626-a2a7-adf1b368c03c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("55b9fb52-116c-4770-ba58-d2c61ffd76a8"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("921679ba-9c13-41fc-9665-b51f1a96f165"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(529), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, new Guid("65f105a5-701c-4f84-a926-88e8c9348aea"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("ed7929de-7b89-4c44-ad11-ed18194b269e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1901), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("f3da1ca7-5bf9-4ef4-8a7c-c31ebc3c67e7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("56719bbd-9a05-4eed-9178-c293788b1989"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1919), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("3acd5291-3778-4618-b0ee-a563c330d1cc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("ea38dba0-2519-44ca-92a4-3edba5acf2d8"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("cda51263-9167-4af2-b2f8-967e10cae06a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("de9ef218-ee04-4729-b226-1cf2f3d46627"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("6a79fa91-2ac3-4a7c-8173-2820a590628d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("78099339-48f4-4271-9da3-75cc6053448f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("de07af74-49e8-4351-bda1-031a264ce510"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2033), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("41accb6b-e2c0-4945-a977-872cca7e758c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2041), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("e78ece56-a0f9-478e-8c0a-60c5a056675a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2050), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, new Guid("c83918d1-7132-47d7-9546-0829ddd50982"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 4, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, new Guid("0c925210-ce07-40cd-99c0-fbffa726921a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 5, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, new Guid("6efaef05-5b06-4de1-8af7-ee70ef76f015"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 6, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2079), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, new Guid("393bfd51-2959-4603-9ffb-b07aff04ef35"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 7, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, new Guid("bbd09e28-a46b-4523-80fb-4fba35a23f34"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 8, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2097), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, new Guid("2a6620b7-d5af-4167-9f0b-af24f15c82d5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 9, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2106), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "license_types",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, new Guid("abadb348-e769-4880-9086-085d87fcdb8d"), "Identification" },
                    { 2, new Guid("dee76fc2-58d0-4293-af39-bae31a89ca86"), "Driver License" },
                    { 3, new Guid("c0dd17f1-2074-42c0-9cdb-b141a5c143ae"), "Vehicle Registration Certificate" }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("e5456a09-30aa-420c-96df-833cfb0b9b5e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(670), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("5b2edaa4-23d2-41ea-9ad1-c540a049bcd2"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(675), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("f5e73788-b820-42bf-8889-4ceea8dc0f66"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(677), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("6029750c-3173-40f5-8dda-ff6bda640dcb"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("933ddac0-e426-44d0-bcb9-0940edbda11a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("105df56b-696b-42d3-82bf-7f81fe19f61a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9414), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ac98ce22-bfb5-4d6e-b847-91425c824a64"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9421), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fbd44451-6248-4c3b-a4bc-736f8e406119"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f18544b7-840f-48f1-9a84-b752d5123624"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9e3145af-c23b-4aae-82be-5fe1b794c4c3"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c23adf8d-99bc-4fc5-875a-59fa5ec1656d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9bceff24-4246-453e-a87c-89b80645756d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9434), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("b83c3cf8-957d-4a5a-9a4b-28c3f3c27a8a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9436), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b619eb5c-10c4-4a57-8975-8132f8123675"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("49eff0ec-efdd-409f-b3b6-a92c239b8f16"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("689cb823-55f3-4f55-ac97-115f74266a3d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c14ad57c-36d5-4da0-a91a-3ea3fc6a5370"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("af94922e-82a6-4af7-b04c-03623c9dd625"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("802436c2-ac38-4d65-8f96-d1fea7093f92"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9481), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6a8f2322-dcce-42c4-8edf-a74d5a71f378"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9484), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("41d2676b-4ede-4abf-ba6a-23ac5d80ac5c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("341a47c9-93c0-4c88-8284-4f0af8d2b301"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9490), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a7a89002-1671-4184-9077-6ef726a787de"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9493), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("112de299-b9e6-4498-b6b3-21d6d2003ded"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9496), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d77ed65c-d9fd-4f89-836b-126860585be2"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9498), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7f2aa0a-6650-4847-bc45-c8ac88743e88"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9500), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8ed8c697-20a3-4298-9ffa-5cf8bc6b845f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("28e6d478-647b-4d62-9652-8b3bf730d597"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9858386c-df80-4b0a-aa86-16fa2ea97c75"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("843070a3-eeeb-4c04-b27d-0fa3e06d69fa"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7597c255-188d-46e4-a91b-00c40ced36ea"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a68d7fc4-dbae-422e-be92-9a9a0c652e33"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("300c8009-328a-42b5-be90-bff12642eb2f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("105cf3eb-efe3-4efc-b775-568ffd251648"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("db66c7ee-d1d8-43fa-b030-17e1f688bd5a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("75a99e2d-b294-4c7d-880a-7f2739647013"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("63943ab2-9cd5-42e3-9273-3632b0bc3bd9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b5441c69-7b09-47d5-a08d-509a093cea53"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9536), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1975d6b9-36f9-415d-9e3e-2195aa3e3675"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9538), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d53e2749-6eab-4e6b-8c42-0489257b7f85"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9541), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hòa, Dĩ An, Bình Dương", new Guid("dbb43ed0-22c5-47fc-a1b5-3ec0c5351ebc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fad724a0-a130-4a62-81f6-af73141b7f43"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ce3d84c4-b822-49b3-ad37-0ea68ebe117c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bfed1599-2e1f-421c-a19a-55c15d062a60"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("67f2be72-6086-453f-86af-c914429b4ae5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c70406db-21b8-4bb9-bc7b-8dd0de4ff46f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("48bd7e96-721b-4c8e-a4a6-8e40258961af"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9558), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("4416055f-5e64-451a-9ae7-40aa21bf4a6b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aac876bd-15f6-40c1-924e-0511c858f924"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d8847eb-ae17-4a01-8f14-4adc5ad045c8"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e3f34865-f311-4a81-9658-9d50fee64273"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9567), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f1c20426-9adc-4d57-a5b1-92c7fdc683d1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9569), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d98e02e5-ae5f-4fc5-b6b5-6fd01630076a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fbbcdfdb-19fe-4970-be47-e4eae5a6935a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b15f3268-dedf-4565-a9c8-cb8a6f554b4c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9b196ab3-3b95-4d03-b52b-e74d7a149132"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9607), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fa15ede9-c8a9-4327-90f3-0ce9d9c2d93e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9610), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4c201995-85e5-41bd-9fe5-ec1f12e2c082"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9612), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cd7c023c-cf32-40b8-8e6d-9ae30412af6c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9614), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8cc7157f-ea76-4fb1-b719-75bbe1821a36"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("25f55334-8485-4b12-99b7-f739358f6c12"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("675c0d4d-72b5-4c39-a36e-0f4bbaf0f53d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5be2a46f-b204-4372-9676-d5277e2f1407"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("94d61ea6-50f5-47a1-a2f0-7127ffce91ba"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("938040fe-1ca2-4510-b71c-f7a671e08325"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("87200d4b-a621-44c7-848f-9bc59b5c9603"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9632), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b3675a2b-2561-4d8e-8d39-6bc596979874"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68d94c78-f734-4594-bd72-5ea1b378bef8"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b6b83b0-ad74-46b5-8eb5-5532d3d679ca"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9639), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("638a7ad3-e205-4102-8ed6-7844b404abb7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ecf2caca-388c-474c-b84e-02dbaceb8cd5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9646), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("56f67d5b-aa5b-4297-b34f-93b575abafb1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1377da0-bce6-48d1-ad16-1fc69a0b7297"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("48815e95-55d2-4245-9625-bbeba1986f57"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9652), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("feb8b8d7-d70b-4064-a848-b27434b52c8d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9654), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b5befd28-f556-4819-b8f5-3e5162c239c7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9657), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fed10e1b-15ea-430d-bbe6-1a4fca1f300f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9659), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cf8c472b-b6ad-4afb-b658-fc727beb27fa"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9663), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("44896167-91d4-49a5-8085-80008356caba"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9665), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7448b89a-8345-4d2a-a7c8-65ffea84aa1f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9667), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9668), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d085b39e-e014-4daa-8f8e-e72e02ab0be1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("86f495a4-61eb-457b-8295-5d93be55e7fa"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f1826991-6da6-4285-81b3-81d17bdd5b30"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("1285127a-15f1-4779-8b70-f5792cb7e564"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9677), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("5de58421-6bd3-459a-9413-9e44120e2d62"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("214bd1c2-32dc-48ac-a5f0-d456e5f5e89e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("33079b78-a607-46c5-baad-93e4f185fcb2"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9685), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("5958b5d0-48e3-45d8-b130-4838ef92647b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9687), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d87c6bd9-6b89-45cf-b2e5-4182c65e6ce7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9502), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô K1-G3 Đường D1, Phường Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("afa09e19-bbdc-4ef0-b5f2-ab4654f4fd9f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9689), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("9af8659e-bfc2-4045-b716-b0af6fc611d6"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2287), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("1430fbd0-accb-468c-baee-8c7d5f7acd78"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("2d79bbf2-752d-4415-9600-d63ca53f749b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2311), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("ac96b9aa-d0dd-47c5-8c1b-a0632be95fc3"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2321), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2343), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 100", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2322), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("708bca93-213d-41e5-8152-3058d4609609"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2358), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 101", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2356), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("6678bb84-6d36-475a-9ea1-59cd098c4f32"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2392), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2395), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 102", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2393), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("57b78033-8b33-47f9-ae5f-9c00895d44a5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 103", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("2e746de6-0184-4799-9997-f7acbcaa7a25"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2420), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 104", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("579aa8ff-7a9a-42cd-b005-adc5d5492bbe"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2435), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 105", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("3ba11018-3c4e-4adb-823a-afba9d3225eb"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2447), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 106", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("e2e2280a-8289-45dc-8706-a4883a329ffe"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 107", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("4f0b625a-22f2-45fc-8ad6-3056bf19c82c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2468), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2471), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 108", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("fe4c03c5-9414-40f5-a15e-eae5f9aad819"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2482), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 109", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("dc4e2d00-8d98-4865-a48f-91b9fba312f0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2494), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2497), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 110", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("79ddf968-c3d3-4c36-bcda-6823a1e3b66a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2506), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 111", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("224fc3a1-63bc-4a5c-a521-dd4c7a049157"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2520), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 112", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("0608d499-105e-4f96-95bc-dcaa6b04a4a7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2562), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 113", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("d0a66ed7-025b-44f6-b177-03cfde5caae2"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2572), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 114", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("d684ddd2-15d3-442d-b697-66bcf165075b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2584), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 115", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2584), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("7c97c5da-0166-486d-a6fc-f421049ad8bc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2595), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2598), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 116", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2596), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("5c7ed689-07ea-476c-8eb0-d1567c44d777"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2609), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2611), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 117", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2609), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("7e358c14-e6dd-4d5c-81df-89526ffd787d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2621), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2623), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 118", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("10e595df-a885-4f43-9e43-5106c22c43b4"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 119", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("2a0cc9b3-8fe3-4fec-93bb-53e917deb060"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2644), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 120", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2645), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("74f16cce-86bc-4cab-bc83-5c09884e5b65"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2660), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2663), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 121", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("46d76ccf-43e9-4277-9457-e7a9c3b0b10d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 122", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("edd11c1d-d5c6-4e24-81aa-c4160d215e59"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2708), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2711), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 123", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2709), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("bf38a9fc-75e5-4f89-8293-ac1855159d80"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2722), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 124", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2723), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("eb823fad-c4bf-4654-b051-0abb6bb82b2a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2736), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2739), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 125", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("b0b193f0-0586-4ca9-b326-df6964f5b3bd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2748), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2751), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 126", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2749), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("8c252709-42b2-4385-8193-e321f37bf1be"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2763), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 127", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("ee7f900f-fa45-4ac2-a8ee-18dee15c4091"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2772), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 128", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2773), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("752b9d6e-d6df-4352-b243-5c020e7c4aad"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2786), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2788), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 129", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("ae0554b9-6e36-4472-a6bb-1774eb333602"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2797), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 130", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2798), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("1ca037af-4a61-4e5a-b394-e2eb125d61c5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2809), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2812), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 131", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("7ce60dbb-8b18-4399-add2-ff77f06126f5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2821), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2824), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 132", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("33289cd9-1666-43da-abce-a12c9606dd9c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2835), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2865), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 133", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("68c65636-b3c3-426d-b4df-0ab65cab5988"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2878), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 134", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("32f5a1a3-ed71-4fce-8bc0-004dd03cd996"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2888), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2890), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 135", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2888), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("b61b75ee-d00f-4d77-89eb-5f7d28f87e62"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2899), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2902), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 136", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("0f49661c-2bfd-47e1-a308-1ec0bff661ed"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2913), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2915), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 137", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("287ba80a-2305-491e-80b6-b03aa12b6473"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2927), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 138", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("d6fd6610-760b-4e5f-b015-ed9f182e8ee0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2937), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2939), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 139", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2937), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("a4329fd6-4ed8-4699-9704-1b7935922c5f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2949), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 140", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("49be332b-24f6-42b8-bd74-1925c7877edd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2965), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 141", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2966), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("5b47214c-022a-4257-bf63-7b789c1d0496"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2978), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2980), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 142", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2978), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("df841f80-005d-4e3c-ac5d-7db0445cf45d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2992), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 143", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("394c4aa9-2629-410f-86d8-a97daa202ebf"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3025), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3028), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 144", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("c03356da-e2f3-4f49-9b4a-4e52e06e5d3e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3043), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 145", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3041), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("f777ebf4-5ceb-4f4b-8b16-20a47be774bb"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3053), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 146", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("7f315b18-8512-4d60-8385-7140721f2f6f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 147", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("d9c15574-1d55-4b05-8d14-8e1517811cdc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3078), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 148", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("7d2a56e1-fe76-4d17-8df6-144512138b2d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3089), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 149", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("1916259f-9a7d-4506-afa5-17df8af81f35"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3103), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 150", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("eb6a79c3-854c-45c3-9628-40769fd3b9c4"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3112), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3115), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 151", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("ebcc637e-846b-4d64-a335-a5bc44b0fcfb"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 152", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("f47fa62a-504a-41d4-b141-04d0f24fe37a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3142), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 153", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("9fae9169-bac3-4cf2-a5a8-44c9faddf2da"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3193), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 154", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("8a33bb94-c7d2-491a-b9be-163ebb50fb1e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3206), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 155", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("4b92ccc7-2030-4739-883f-d293d938426f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3220), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 156", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("d324f439-94f5-4472-b1ea-9440669e9f99"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3231), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3234), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 157", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("dff5863e-f02a-481c-9d0a-08e78e933f79"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3243), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 158", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("48806a97-de7c-4ca4-9d54-05785fb679a7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3254), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 159", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3255), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("dab412c8-89c2-4c4c-97ce-cc27f28286bc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 160", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("f55a2af7-5bd3-4119-8ff1-e7e850321a1d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 161", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3280), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("7df271aa-7fe6-466a-ae13-d908206e050a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3291), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3293), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 162", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("0d95eeaf-01e6-4b0d-9496-6e583041cc04"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 163", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("803caca6-5772-44a9-84b1-d3a4c344a625"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3342), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 164", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("41573894-3b1d-4672-b816-3a4545a5cc70"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3357), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3360), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 165", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("092a7658-cc81-41da-a020-62f53c3f7dee"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3369), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3372), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 166", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3370), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("6689642f-ce43-4366-9b7c-7f048400b391"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3381), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3384), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 167", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("413b0909-b25f-4cb3-bc48-c1f7eef31a7c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3395), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 168", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("83949ffb-0ee0-4016-b986-0d3e40201a6b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3409), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 169", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3407), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("b06da83e-590c-4715-a01d-94709817ade6"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 170", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3419), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("05a4e77c-25bf-4d6c-818e-4a093c56feae"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3432), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 171", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("8326bd7d-6beb-4fb0-bbbb-8ecb52e72cad"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3441), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 172", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("9a75c3b9-308d-4533-9460-36055e469209"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3455), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3458), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 173", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("f0a29bbb-ebba-4545-bae9-d38375ba7f35"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3467), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3470), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 174", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3468), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("aaa01e7f-15d9-4206-8ac9-0d12e2291bfc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3507), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3510), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 175", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3508), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("96b633aa-0426-4a4b-8f2c-2d619c08c8d0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3523), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 176", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3521), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("162faea9-bf4e-44b7-a272-78c3ff548dfc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3533), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3536), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 177", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3534), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("c3ad71ff-ea8d-4627-852e-4916a45ad078"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3545), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3548), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 178", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("94adbd54-6ec8-4268-9d6b-96e35969997d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3557), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3559), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 179", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3558), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("d9bceff7-1cd7-4a5e-9bc4-34a070ab6609"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3568), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3571), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 180", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3569), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("5bd41313-9a00-40c2-8bd2-44891f7db6e1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3582), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 181", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3583), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("e1d7cc3e-6af7-4213-8e8e-5e902e21d7e7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3594), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3596), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 182", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3594), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("5617988d-ee13-470c-aa57-803d6409e4f1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3606), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 183", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("20de3666-eac8-4183-b5aa-2f9a9fa48f16"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3617), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3620), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 184", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("a2b1c5f8-f9b9-4a7d-92cc-1be41f524092"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3631), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3633), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 185", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3631), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("1ab48702-bbba-49b7-91e5-5b7a66be2128"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3671), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3674), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 186", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("a2cdeaf0-0bff-4cca-bc9e-1feaac0888ea"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3684), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3687), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 187", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("1c4283ca-4d4d-415e-94e3-6932d283bfe4"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3696), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3699), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 188", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3697), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("fc0952c4-6546-4528-8ecd-b32ed92856b0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3712), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 189", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("ed5f05ad-76c4-4cef-8d65-780d79abdf3d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3721), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3724), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 190", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3722), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("73f0208d-3306-4f92-b061-aea95aa62677"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3733), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3736), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 191", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3734), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("3b846f32-51fa-4525-a12e-20f7df7f69dc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3745), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3747), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 192", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3745), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("007ee453-1a4a-42cd-a2d6-9b24eaf9425d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3761), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 193", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3759), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("a070c738-8058-49fa-aa4c-ac6c96c555ab"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3770), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3773), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 194", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("793cf385-5f86-4732-b890-5f7b47398e7e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3784), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 195", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("6835800b-ef60-4bcb-8f2c-44efed00dfd5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3795), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 196", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("2f39a8f5-da3b-4a6f-8b52-9adbbc71eb80"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3835), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3838), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 197", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("88178266-7db4-41a5-b362-1faf38889d40"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3850), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 198", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("ac58b7cd-70b6-4156-932a-fb58737af2cc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3859), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3862), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 199", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3860), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("a7556e1c-849f-4633-bbe2-5e2486239d64"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("814e9505-1b54-40f1-b2fb-214500f2bb83"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3886), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("e827febc-5740-4bfe-8325-0f8a02c40c20"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("f1307435-6ce1-4d9b-97e5-d1ad552c5ef5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3908), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("aaf9850f-bdd7-4715-868b-1c5fb3822905"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("7b4c2461-4b3b-481f-b843-d50db903bc05"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3930), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("e60676ac-ae26-494b-be7b-98d87bc0fe66"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("fb32e333-7d88-4833-b962-db753ad148de"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3981), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("4fe66e9c-7a36-4b24-a75a-3fd0d718997a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(3994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("01b1d639-3de4-410e-8404-497eccefb738"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("64f02bfb-16dc-44ae-b7c2-54c2003f5040"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("baee69b9-459c-4a7b-b83d-e934097f0a47"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4027), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("247870a8-0e0c-4558-a7ec-d9ff69383e32"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("d089bb03-69c1-4e79-8d91-5768a8f10155"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4050), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("a817b03a-7be2-4f60-befd-6e14ed4faa8f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("145d9533-13ba-4119-bd26-fcbae48c64e3"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("df441315-226b-4938-aa8e-42952456a917"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4081), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("e4b1ad7f-e7f5-44dd-af57-58079e50ca1e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4124), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("6ea33e03-a269-49e3-8173-a219fc762abe"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("5410846f-cb69-4d73-8244-a16dc8674967"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("d4ca1cc8-de87-40c5-b7be-31ac1866a715"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("83019f1c-8c24-4b4c-a936-7cf85f3252ad"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("4a67fd3b-053d-48c8-b0a6-5aadf0bca8e9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("5bf9be54-038a-4038-8502-7b6e27969df9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4191), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("40c4e1a5-a0cf-4edc-b396-7441e11f9e78"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("ee018da3-91e7-480b-9997-2a8f727594fd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("a11bd38a-d2c8-4efb-a611-67c0a9ba8c97"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("4fc7a683-c20f-4fc5-9bb3-6a1f2b220a07"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4264), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("47da5078-3e9e-4697-bb7c-09b1595845e1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("e5f0935d-8593-41c4-b601-f85f38af62f4"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("190c9282-678c-4e51-bef0-3c97b985436e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("3fd44d6f-2ed2-4760-ad94-f711ccc92085"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("9160b44a-5cca-477f-bc8a-bdf3e9be9b1c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4318), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("d2b84480-a753-419a-a451-031bf57182dd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4330), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("04a8a242-697f-468a-970d-4b5de8aaecb2"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("6f5cbec5-286a-4081-8d0c-bbda22b4b14e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("1aa97fd0-cdbe-4cc9-b681-ea0f55cab87e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("3ad07def-4066-4e74-b1a6-149dcd17ffcf"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4410), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("e0464d2f-f04b-4b2e-87a7-015d688464e4"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("a39fc98e-50b0-4683-a4c2-3d40c641ceab"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("f46a97ef-b851-4d6b-ae68-489548cb42c7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("201ff1af-1493-474b-9c0e-402e04b208f7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("d57a9445-a269-46a5-8e29-b6c9240d5a6d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4467), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("9308d48b-c47c-4edc-aa29-b245fe2f4874"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("d3c6f117-9004-4826-90a1-b09dd3c6982a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("b23c44bf-c25c-43e6-b227-18bdf85635c0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("d7833271-f951-44e7-86ff-7865afd2c24f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("95ed6110-81b1-473b-bc05-a8431e282173"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4521), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("92f5db45-7a77-4ac0-b3d8-4e512833ef8a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4563), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("d7a25ccc-ecf3-4f34-826c-797511a69a73"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("49eaf338-956d-4327-a4cd-af89c58ebe2c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("58d2c6c2-1f76-4391-a2ed-c875e90ae484"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4597), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("491dff27-fe30-49d2-8e97-484cbd8390c0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4608), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("35b50fa9-9029-4fbb-b2b5-e955d5e93e29"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("dca3a52d-0c93-4cd6-9cb6-9b8d0b9c5a35"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4631), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("99fbbdbb-19a4-4590-aab6-2fa0cb1e409c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("f0606aa7-f385-450e-b621-0cb4ec1dc1ec"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4652), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("36ccc915-114d-4166-8904-d1230e89d8dd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4665), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("61daf1ab-fc15-429a-bbb4-7c2a3d73b98e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("2fd277a4-2a6d-40b3-8c99-a0ab8b9cc4ac"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4714), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("20b2a0fe-8dd5-47f4-a99d-cb08875a7fe1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4725), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("d855d512-31ea-46c2-b94b-bae29709d066"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("08947905-b570-435d-8210-907507cae0b9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4747), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("08faac00-0ea6-41d5-b3e8-d0ca2e0c8902"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("8281482f-eda9-45c3-bffa-70d518463205"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4768), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("359ad868-3ce0-4b2a-990c-018d85ea05c1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4781), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("883892bf-e26f-430e-bfcf-447dada7d556"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4791), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("245b3d8b-2438-43c5-bf06-9e0ad46c4594"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4802), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("d2d8173b-a03f-4efd-a2ca-aaf33cf3131b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4812), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("3347f672-00d8-4423-80f2-0bd737419889"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("f8bd19fa-5f37-469c-9fee-ef11fd59ec38"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("b4234316-1ee0-4af8-8539-d8570517b38e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4877), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("ca612b6e-5afe-47a9-b1b7-2bddab0daa24"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("80ddd27f-f3a6-41cb-9209-9b97f1bd4744"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4899), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("369e57ec-bad3-4ed1-95b8-862e520dfe99"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("1709fe87-0257-4f52-be99-2386a9fa47b8"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("2a120653-c864-4847-929e-6f3b613268cd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("1cb16f1e-fe20-4645-a719-13202250188c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("14e368f4-a437-4aa8-80b6-a3cdbd52b0ba"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4954), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("839efc32-9012-4f19-8410-50a3cf4fc5d1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(4964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("c651df48-d29b-4a5d-b769-0793cfbe9ae5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("c68dab69-4e0d-4089-ba92-5fea660b3c9f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5020), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("3dcb4bcb-6a0e-46c0-a1d0-b7427f28a7a5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("560b2423-4297-45f5-a818-b1937df517c0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("c4f33df0-2f66-4d51-9f21-f7ee0d54e29b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("997636b0-e293-4a0a-b40d-8504f89677be"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5064), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("d1244e26-5b9f-4a1c-81dc-f202c70c132a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5075), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("c5d131ea-2499-4815-bb19-f4c4c7a266bb"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("b76f936d-a552-47a8-962a-83d3053e9f70"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("ebd83cd6-6188-4472-a63c-13f4d25a50aa"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5108), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("887246c0-82be-431e-bc69-02e1114359d9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5118), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("c4cba9e9-dfde-47e9-b885-e6ccc3635d80"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5160), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("8b154cba-3f59-4d2e-9f98-cc5a5396d9b1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("0bc387c0-8e02-4fa4-aa63-9a530e2dc888"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5183), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("dde63cfa-a438-4d2f-ac6c-01fd9ac8b9d0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("fda3ffc6-7097-4e28-b212-604b4d7310b6"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("38424f9f-faec-40f5-a733-4b5bb72eeecd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5216), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("13afdcd2-d2aa-4280-86a2-745d6b78556e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("41d78d99-2434-4616-ac7a-88847bbf7d30"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5239), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("d8bfaca7-10eb-400b-984f-a1db874919b3"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "name", "slot", "status", "type" },
                values: new object[,]
                {
                    { 1, new Guid("682455c0-9f3d-43a9-b821-6ce555171e9f"), "ViRide", 2, 1, 0 },
                    { 2, new Guid("7eadc528-201b-4d7f-bc24-9503d046a0e2"), "ViCar-4", 4, 1, 1 },
                    { 3, new Guid("bf598244-62b3-4d1b-95ca-29823e26d5d6"), "ViCar-7", 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[] { 9, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 7, 0, 0, 0)), 0, null });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5433), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5440), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5448), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5455), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5462), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5468), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5476), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5486), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5526), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5535), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5549), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5556), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5563), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5570), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5579), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5587), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5594), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5602), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5609), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5616), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5624), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5646), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5653), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5661), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5668), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5721), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5738), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5745), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5753), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5761), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5768), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5775), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5782), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5790), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5797), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5804), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5811), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5825), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5833), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5840), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5847), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5856), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5892), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5930), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5937), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5952), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5967), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5981), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5996), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6003), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6010), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6039), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6046), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6080), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6088), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6096), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6104), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6111), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6118), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6126), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6156), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6164), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6172), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6179), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6186), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6193), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6201), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6208), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6216), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6223), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6231), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6238), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6295), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6317), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6325), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6332), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6347), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6355), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6362), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6376), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6391), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6398), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6405), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6443), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6451), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6458), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6474), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6488), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6496), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6504), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6511), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6518), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6526), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6533), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6541), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6548), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6555), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6562), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6569), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6584), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6618), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6627), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6642), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6649), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6656), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6678), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6686), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6693), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6701), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6708), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6716), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6723), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6730), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6745), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6752), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6759), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6767), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6774), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6807), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6824), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6831), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6846), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6853), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6861), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6868), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6877), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6884), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6891), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6899), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6913), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6921), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6928), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6935), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6943), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6950), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6957), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6965), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(6972), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7004), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7011), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7018), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7026), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7033), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7040), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7048), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7055), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7063), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7077), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7085), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7092), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7099), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7107), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7114), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7121), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7128), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7143), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7151), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7158), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7200), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7208), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7215), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7222), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7229), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7237), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7244), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7252), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7259), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7268), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7276), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7283), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7297), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7304), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7311), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7319), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7326), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7348), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7355), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7389), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7397), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7405), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7412), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7426), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7434), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7441), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7448), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7456), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7463), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7471), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7478), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7486), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7493), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7500), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7508), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7515), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7523), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7562), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7570), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7592), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7606), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7613), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7635), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7642), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7657), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7690), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7699), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7707), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7716), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7752), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7775), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7782), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7789), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7797), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7804), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7811), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7819), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7834), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7841), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7848), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7856), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7897), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7907), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7915), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7922), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7929), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7936), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7944), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7951), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7966), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7973), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7981), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7988), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(7996), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8026), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8040), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8048), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8055), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8111), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8122), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8137), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8152), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8159), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8167), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8174), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8181), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8188), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8196), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8203), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8218), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8225), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8240), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8255), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8262), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8269), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8276), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8321), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8329), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8336), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8344), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8351), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8359), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8366), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8374), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8381), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8388), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8395), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8403), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8410), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8418), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8425), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8440), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8447), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8454), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8462), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8469), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8522), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8529), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8536), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8559), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8566), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8573), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8602), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8610), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8617), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8624), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8631), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8639), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8646), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8654), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8661), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8714), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8722), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8729), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8737), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8744), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8759), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8767), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8774), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8781), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8788), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8796), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8803), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8810), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8817), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8832), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8839), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8846), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8854), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8861), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8903), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8918), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8947), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8954), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8969), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8976), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8983), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(8998), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9006), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9020), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9028), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9035), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9747), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9756), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_type_id" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9277), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9293), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9130), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "settings",
                columns: new[] { "id", "data_type_id", "data_unit_id", "key", "type_id", "value" },
                values: new object[,]
                {
                    { 0, 1, 2, "AllowedMappingTimeRange", 0, "3" },
                    { 1, 1, 2, "TimeBeforeToPickUp", 1, "10" },
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
                    { 27, 1, 2, "TimeBeforeToStartTrip", 1, "60" },
                    { 28, 1, 2, "TimeAfterToStartTrip", 1, "5" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("1bf6d6aa-7362-4bc4-a507-847a1ad394fd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2130), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 7, 0, 0, 0)), null, null, 1, 1, "Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2130), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("6cd9b43f-6863-46c3-ba58-a80da94a18e2"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2155), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2157), new TimeSpan(0, 7, 0, 0, 0)), null, null, 2, 1, "Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2155), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("2fa2a405-0084-4696-9d5a-a48b9907c270"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2168), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2170), new TimeSpan(0, 7, 0, 0, 0)), null, null, 3, 1, "Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2169), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("429a0dac-1cbd-47c6-a1db-db180eb778ff"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2205), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2208), new TimeSpan(0, 7, 0, 0, 0)), null, null, 4, 1, "Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("b578bd1b-d5e2-42e0-a661-baf49814be2f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2220), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2222), new TimeSpan(0, 7, 0, 0, 0)), null, null, 5, 1, "Loi Quach", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2221), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("5e8dcea6-9ade-4e4a-aa72-246aac22b91b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2236), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 7, 0, 0, 0)), null, null, 6, 1, "Dat Do", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("fa7cb149-ea68-4059-83f8-487ddc41f23f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2248), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 7, 0, 0, 0)), null, null, 7, 1, "Khoa Nguyen", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("32f3f4d7-d0c8-40d1-87ff-6311bc106f99"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, 7, 0, 0, 0)), null, null, 8, 1, "Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("e89060ba-f98a-4235-9e77-68ec5e8d4539"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2272), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 7, 0, 0, 0)), null, null, 13, 1, "Admin Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("10192aa4-6a7d-48e4-a884-55916325a3a3"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(15), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(15), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 2 },
                    { 401, new Guid("ff2fbab4-c123-42b0-89c6-fe58b877b1b1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(56), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(57), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 2 },
                    { 402, new Guid("3495993d-6f45-438d-a99f-561bc11ced58"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(62), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(62), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 2 },
                    { 403, new Guid("4a76c1af-cfab-4cbb-81c8-400d123dcb01"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 2 },
                    { 404, new Guid("9f86603e-9c19-4c71-9294-b201bd599e1f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(68), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(68), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 2 },
                    { 405, new Guid("0a715b25-21bc-4770-b117-b2237b788ed2"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(71), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(72), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 2 },
                    { 406, new Guid("e39cbc9f-fcc3-4e2d-9690-02031153e685"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(74), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(75), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 2 },
                    { 407, new Guid("43e832e6-2d61-49f9-bc2b-bba9eb323f46"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(78), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 2 },
                    { 408, new Guid("eef113a7-19e4-43dc-a81f-fd758d78ad6f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(80), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(81), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 2 },
                    { 409, new Guid("a7f3f1d3-b149-45e4-b244-1d64b77d02df"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(83), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(83), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 2 },
                    { 410, new Guid("96613bb1-54db-4c74-af04-03923f9b36e9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(87), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(88), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 2 },
                    { 411, new Guid("1b65f19c-e0f3-44f3-8880-8ba5e9110406"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(90), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(91), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 2 },
                    { 412, new Guid("4af4ed4d-954a-4ba8-92ec-c28c8c0e837d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(94), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 2 },
                    { 413, new Guid("92ad1594-7185-4cc8-9e66-2dda8745a4e4"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(97), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(97), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 2 },
                    { 414, new Guid("d79ebb9a-2027-48a0-b1c3-9d2ae6fd15ab"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(101), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 2 },
                    { 415, new Guid("a8415ef8-6886-47b9-86ff-71398cb1b6db"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(104), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 2 },
                    { 416, new Guid("ee1e30b9-9afc-4f98-bc30-e2accb470720"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(107), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 2 },
                    { 417, new Guid("65e9d96e-82d2-49e2-913f-bb72dae7090b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(110), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 2 },
                    { 418, new Guid("d599bb15-d348-4138-bd51-dba4a2c1d690"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(114), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 2 },
                    { 419, new Guid("d5066d05-1fee-4a7c-b4b2-a27d913d4b5f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(117), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 2 },
                    { 420, new Guid("b6dfd5c7-d5dc-445e-8427-85394766d2a7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 2 },
                    { 421, new Guid("a0fa271b-04ce-498a-895d-8641896b3766"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(123), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 2 },
                    { 422, new Guid("55b58724-5bec-424c-b9c7-f41d34b19b65"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(126), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 2 },
                    { 423, new Guid("ab44c30e-7c90-49ff-a930-7b32f81cab47"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(129), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 2 },
                    { 424, new Guid("d9d7fdd4-66fd-4496-89d8-48229749edf5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(132), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 2 },
                    { 425, new Guid("3fd3f19c-c361-4346-a335-849450be52d0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(134), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 2 },
                    { 426, new Guid("6f339630-4367-495c-84e1-693d30384932"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(139), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 2 },
                    { 427, new Guid("5bdc45da-53c1-4ff4-a3ed-59918c95eac0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(142), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 2 },
                    { 428, new Guid("e936b6aa-730b-40f0-bb76-b24ff0f1dc9b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(145), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 2 },
                    { 429, new Guid("4f914ecb-db3b-4ace-bf5a-6e4ff8ce9dab"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(148), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 2 },
                    { 430, new Guid("ca9acd81-3b16-4189-9fc0-540fd3409168"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 2 },
                    { 431, new Guid("66047c2a-5183-448a-890b-f2d9127d404b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(181), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 2 },
                    { 432, new Guid("b8072eff-6531-46d7-ae76-4d07179b2d88"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(185), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 2 },
                    { 433, new Guid("e3c1156b-0d93-4239-b9be-703a3260cedf"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(188), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 2 },
                    { 434, new Guid("2e41b72f-cc6e-47a9-928e-414d7e2c94ce"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(192), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 2 },
                    { 435, new Guid("9ac98b77-8e69-4147-b323-32669f97091d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(195), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 2 },
                    { 436, new Guid("02b3514e-c9d0-440f-bd79-92b6aa9f3017"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 2 },
                    { 437, new Guid("3c2a3701-53b6-4afe-a0c3-a1eb5ad46fca"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(201), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 2 },
                    { 438, new Guid("55073fe9-aa5d-40de-b60e-58798e5b8763"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(204), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 2 },
                    { 439, new Guid("48e3e3ec-5763-47b4-b52f-35df60038c1e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(207), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 2 },
                    { 440, new Guid("c580139d-dac6-442a-9dcd-b09fd2b8d0c3"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 2 },
                    { 441, new Guid("a089160a-4550-4837-bb19-2a0736307fd6"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(213), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 2 },
                    { 442, new Guid("3301daa0-8be5-424c-9e5c-0c56e40f7e43"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(217), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 2 },
                    { 443, new Guid("3420a628-06f3-40d5-982b-3062f4d0c9bd"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 2 },
                    { 444, new Guid("28d01056-364f-42b7-9325-2bdc7c2aea81"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(223), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 2 },
                    { 445, new Guid("70dc52f4-2b6a-4bb3-b831-7614bcc0c4a3"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 2 },
                    { 446, new Guid("1a7e9c5f-d11a-4325-bd5b-5588c392a1db"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(229), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 2 },
                    { 447, new Guid("b3fad1d9-96a5-496b-b7fb-e6842432fd4d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 2 },
                    { 448, new Guid("19ae6a01-50f5-4023-add0-5d902e2ecaad"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(235), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 2 },
                    { 449, new Guid("b9870b15-458a-4d12-b942-45df80923bf4"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 2 },
                    { 450, new Guid("4908c56f-29bf-4589-ab13-b0b74b75ff90"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(242), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 2 },
                    { 451, new Guid("22ee5dbc-4e57-42db-b617-3dad7426aec9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(245), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 2 },
                    { 452, new Guid("cdeeac51-6ed4-4a9e-8e8c-73366a9f2fe9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(248), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 2 },
                    { 453, new Guid("ea466274-ae52-401c-b3b8-55991674f946"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(251), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 2 },
                    { 454, new Guid("9e6e189e-b02b-4cce-b29e-963962a8c67b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(254), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 2 },
                    { 455, new Guid("79aca6d4-b067-4075-824d-b96d6f2ad7a5"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(257), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 2 },
                    { 456, new Guid("49a94c74-0ab6-47e6-9925-b2aad069d62b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(260), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 2 },
                    { 457, new Guid("391e9a00-e2ff-4422-a78f-09f3b2eadd7d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(263), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 2 },
                    { 458, new Guid("369f6e6e-46a7-417b-943c-cf4d923fbfce"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 2 },
                    { 459, new Guid("c6d2e003-2eb8-4887-ad84-b061e212137e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(271), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 2 },
                    { 460, new Guid("d41fc6a3-a150-4f36-8e39-4694bf46afab"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(274), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 2 },
                    { 461, new Guid("05cc5fbd-2cfb-4694-8530-192217e0eaef"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(320), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 2 },
                    { 462, new Guid("7eacd210-22c1-46d1-9cec-ae697ec9ca2e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(323), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 2 },
                    { 463, new Guid("4051e694-f26a-4e6f-8c66-5c119502021e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(326), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 2 },
                    { 464, new Guid("8b1dc5bc-5852-40f0-964a-e18340efd110"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(329), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 2 },
                    { 465, new Guid("706a5aec-886e-4702-831b-6a40b977743c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(332), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 2 },
                    { 466, new Guid("4bc60058-f297-4df4-810d-0fdbbeb93ab7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(336), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 2 },
                    { 467, new Guid("c4dd0312-4cb8-4963-a5d1-c57cefe1d68d"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(339), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 2 },
                    { 468, new Guid("2b8d45d0-e7e1-46a2-a942-512367350b71"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(342), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 2 },
                    { 469, new Guid("c6a385d4-1047-439b-a026-b628cbf9c5fc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(345), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 2 },
                    { 470, new Guid("858df3c9-6dec-4d7f-afea-80dd5bcdad9a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 2 },
                    { 471, new Guid("cf04d19a-4b97-416a-97a3-3e6ddb92a0ff"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(351), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 2 },
                    { 472, new Guid("a0e0170c-6857-4154-89ce-f983704763f4"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(354), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 2 },
                    { 473, new Guid("c1e29a12-5fce-411c-b2bc-1b50deac8b92"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(357), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 2 },
                    { 474, new Guid("8f92bdfa-52cf-4433-9bf3-d1934771f731"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(361), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 2 },
                    { 475, new Guid("a07f259b-3139-4914-ae19-9506a6e1b568"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(364), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 2 },
                    { 476, new Guid("e4292d04-6745-4899-b81c-4bfc45875b26"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(367), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 2 },
                    { 477, new Guid("af6cfebe-3d3b-4fcc-8574-b89f902a458c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(370), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 2 },
                    { 478, new Guid("4ee7d619-65f3-47f0-a83f-95c80e8c3fac"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(373), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 2 },
                    { 479, new Guid("65331338-b68c-4f68-8582-92c69ab45790"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(376), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 2 },
                    { 480, new Guid("5af60763-660b-43ae-8749-5219dd308827"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(379), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 2 },
                    { 481, new Guid("ba3eb4cb-8db0-4fae-872f-4c635b3e71d7"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(382), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 2 },
                    { 482, new Guid("6da4e948-ff5e-4f4a-acd9-4aa9d652935f"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(386), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 2 },
                    { 483, new Guid("f00a6406-3f7d-46ae-8bec-00fd31a26be9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(389), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 2 },
                    { 484, new Guid("fd3dc69c-d536-4ce7-ad9c-022b51cba7df"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 2 },
                    { 485, new Guid("dfe7dd06-0014-4a3d-8ddd-61508e50da0c"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 2 },
                    { 486, new Guid("2d3c1f79-2a0b-493a-b8e7-ccd5e4ee1447"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 2 },
                    { 487, new Guid("b8be40b7-976f-4b74-abf6-15ea3c77cf1a"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 2 },
                    { 488, new Guid("ff4a79af-6a87-4769-b055-eca79d07225e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(404), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 2 },
                    { 489, new Guid("cfae7872-8041-4a16-9589-e8a4df42dda0"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 2 },
                    { 490, new Guid("bb0e3b41-251d-40a7-ab4d-4bf26ec3b82e"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(411), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 2 },
                    { 491, new Guid("3e6b1bea-10ef-4174-b363-21624e8aba49"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(414), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 2 },
                    { 492, new Guid("688769bc-13f5-4e0c-9318-16a4f65e83a2"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(417), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 2 },
                    { 493, new Guid("15d2a1b8-410c-40a1-b742-b0dce3c422fb"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(420), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 2 },
                    { 494, new Guid("50de09aa-d72a-4c07-99df-5f7c3ec74568"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 2 },
                    { 495, new Guid("926c51a4-3828-4783-b90c-a8251d327ee9"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(453), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 2 },
                    { 496, new Guid("faffd3d6-cfc7-447c-b8d7-5d1f9e35e624"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(456), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 2 },
                    { 497, new Guid("5b1a3d28-9862-45da-9d2b-5c24d21c58ea"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(459), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 2 },
                    { 498, new Guid("cbe81663-5226-4dc1-8ce9-8614d63119b1"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(463), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 2 },
                    { 499, new Guid("53cac0ef-3232-49f8-8b0c-2a1e9872c795"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(466), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 2 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5268), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5280), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5322), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5331), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5339), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5347), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5354), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5383), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5405), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5412), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5419), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(5427), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9858), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9898), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9919), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9934), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9961), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9974), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9151), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9241), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9313), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9336), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9366), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 356, DateTimeKind.Unspecified).AddTicks(9378), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "user_licenses",
                columns: new[] { "id", "back_side_file_id", "code", "created_at", "created_by", "deleted_at", "front_side_file_id", "license_type_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 15, "1f363c5e-8c4e-4e08-b127-5dd1606c7148", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(1357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 14, 1, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(1360), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 17, "d1267b63-e9bf-46c8-9dff-62ec0cd879b9", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(1379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 16, 2, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(1379), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, 19, "2525c3bc-db73-42ec-9d47-3744934c251f", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(1391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 18, 3, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(1392), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("6d7fb345-c9f3-429c-a7c2-795c0f5e6e70"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(3), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(4), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("a0f38ee5-9963-4c89-ad13-b1e265499485"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(8), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(9), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("15280db6-808c-4a23-9e4c-fab78ebdec8b"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(10), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(11), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("51613b4d-9fab-4d79-8d6a-fd68d81cb2cc"), new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(12), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(13), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(561), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(565), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(567), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(570), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(574), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 0.0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 4, 22, 9, 19, 357, DateTimeKind.Unspecified).AddTicks(576), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
