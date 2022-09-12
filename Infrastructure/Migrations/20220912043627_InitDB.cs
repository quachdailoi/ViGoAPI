using System;
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
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("0d745d14-b83c-4e7d-9b59-a8dbe74ffa7e")),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "verified_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    expired_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    registration = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    registration_type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verified_codes", x => x.id);
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
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    file_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                name: "promotion_conditions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    promotion_id = table.Column<int>(type: "integer", nullable: false),
                    total_usage = table.Column<int>(type: "integer", nullable: true),
                    usage_per_user = table.Column<int>(type: "integer", nullable: true),
                    valid_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    valid_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    min_total_price = table.Column<float>(type: "real", nullable: true),
                    min_tickets = table.Column<int>(type: "integer", nullable: true),
                    payment_method = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("8348a9f7-6c87-4b81-a5fe-df30e2e4d3a9")),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    option = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    days = table.Column<DaySchedule>(type: "jsonb", nullable: false),
                    is_shared = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    from = table.Column<Location>(type: "jsonb", nullable: false),
                    to = table.Column<Location>(type: "jsonb", nullable: false),
                    start_at = table.Column<DateOnly>(type: "date", nullable: false),
                    end_at = table.Column<DateOnly>(type: "date", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    promotion_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookings_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_users_user_id",
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
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                name: "user_rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    last_seen_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2022, 9, 12, 4, 36, 26, 873, DateTimeKind.Utc).AddTicks(9534)),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                name: "promotion_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    promotion_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    used = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    expired_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PromotionConditionId = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    driver_id = table.Column<int>(type: "integer", nullable: false),
                    message_room_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_details_users_driver_id",
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
                    { 1, new Guid("93f42e9c-30d2-44c1-bab0-4b14b01bdb4e"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7400), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7401), 0 },
                    { 2, new Guid("efd8c4dd-01c7-4ec6-b0bd-ff589625c224"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7415), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7415), 0 },
                    { 3, new Guid("75709067-7e7d-4c27-a2ff-93b9df4179f6"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7422), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7422), 0 },
                    { 4, new Guid("49182200-c89a-49d1-96c9-7d4d49a5afa0"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7439), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7440), 0 },
                    { 5, new Guid("b83a693a-4e6d-4c30-b713-a0671cebcb58"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7447), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7448), 0 },
                    { 6, new Guid("2f3e07d8-f0bb-4ff5-ba45-a6598cefa46d"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7456), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7456), 0 },
                    { 7, new Guid("26d4def9-730b-4790-bde0-f4dc044eb9bc"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7463), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7463), 0 },
                    { 8, new Guid("210b9ea0-b568-49cf-be97-a7d25494502a"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7470), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7470), 0 },
                    { 9, new Guid("dc1a498a-3c6f-44d1-bcb7-4d00bab88d74"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7476), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7476), 0 },
                    { 10, new Guid("acb92608-f98f-4cdc-9802-cb159be9e436"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7484), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7484), 0 },
                    { 11, new Guid("1308348c-dc6c-40c6-98b0-0718234e5ef8"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7491), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7491), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[] { 3, "HOLIDAY", new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8022), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8022), 0 });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Role for booker", "BOOKER" },
                    { 2, "Role for driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_method", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until" },
                values: new object[] { 3, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8166), 0, null, null, 1000000f, null, 3, 50, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8167), 0, 1, new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Utc), new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8005), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8006), 0 },
                    { 2, "BDAY2022", new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8016), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8016), 0 },
                    { 4, "ABC", new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8028), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, 11, 300000.0, "ABC Promotion", 1, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8029), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("912217ae-a4c4-45a4-b3af-c3253f6b1b34"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7508), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7508), 0 },
                    { 2, new Guid("09eec144-2b3c-45ca-8e16-0583a78f095b"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7520), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7520), 0 },
                    { 3, new Guid("72bbceb2-6610-4e12-8ac2-901332aa6608"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7565), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7566), 0 },
                    { 4, new Guid("0165bf53-d100-4833-964f-b70796450eab"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7791), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7792), 0 },
                    { 5, new Guid("f675d68c-9889-4402-93f6-cdf0404057bd"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7815), 0, null, null, 5, 1, "Loi Quach", 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7815), 0 },
                    { 6, new Guid("97ff65e3-7095-4899-ade1-0fb843f7e41b"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7830), 0, null, null, 6, 1, "Dat Do", 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7830), 0 },
                    { 7, new Guid("cfa6c4b8-5283-463a-b44e-385c32d40f8e"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7841), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7841), 0 },
                    { 8, new Guid("61e44e9a-78b9-4bdf-af2f-d8152014d113"), new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7850), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7850), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7861), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7861), 0, 2, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7869), 0, null, "+84837226239", 1, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7870), 0, 2 },
                    { 3, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7877), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7877), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7883), 0, null, "+84837226239", 1, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7883), 0, 5, true },
                    { 5, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7889), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7889), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7896), 0, null, "+84377322919", 1, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7896), 0, 2 },
                    { 7, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7902), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7902), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7907), 0, null, "+84377322919", 1, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7908), 0, 6, true },
                    { 9, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7914), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7914), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7921), 0, null, "+84914669962", 1, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7921), 0, 3 },
                    { 11, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7926), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7927), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7932), 0, null, "+84914669962", 1, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7933), 0, 7, true },
                    { 13, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7938), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7938), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7944), 0, null, "+84376826328", 1, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7944), 0, 4 },
                    { 15, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7950), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7950), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7991), 0, null, "+84376826328", 1, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(7991), 0, 8, true });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_method", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8042), 0, null, null, 500000f, null, 1, null, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8042), 0, 1, new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Utc), null },
                    { 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8144), 0, null, null, 200000f, null, 2, 50, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8144), 0, 4, new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Utc), new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8185), 0, null, 20, 500000f, null, 4, 50, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8185), 0, 1, new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Utc), new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8204), 0, null, new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Utc), null, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8204), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8223), 0, null, new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Utc), null, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8224), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8237), 0, null, new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Utc), null, 1, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8237), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8250), 0, null, null, null, 2, new DateTime(2022, 9, 12, 4, 36, 26, 876, DateTimeKind.Utc).AddTicks(8250), 0, 2, 6 });

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
                name: "IX_bookings_user_id",
                table: "bookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_room_id",
                table: "messages",
                column: "room_id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "booking_details");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "promotion_users");

            migrationBuilder.DropTable(
                name: "user_rooms");

            migrationBuilder.DropTable(
                name: "verified_codes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "promotion_conditions");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
