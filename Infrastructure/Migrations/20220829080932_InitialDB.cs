using System;
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
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
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                    time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    option = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    days = table.Column<string>(type: "text", nullable: false),
                    is_shared = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    from = table.Column<string>(type: "text", nullable: false),
                    to = table.Column<string>(type: "text", nullable: false),
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
                    last_seen_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2022, 8, 29, 8, 9, 31, 949, DateTimeKind.Utc).AddTicks(9715)),
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
                    { 1, new Guid("71de5b78-6d5a-463b-be56-3f6ed23851df"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8719), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8720), 0 },
                    { 2, new Guid("60d8349d-10b3-4530-9e11-bcb157448819"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8762), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8762), 0 },
                    { 3, new Guid("6ac9818c-8bd0-467a-9b68-c10edb768831"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8833), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8834), 0 },
                    { 4, new Guid("46f232cc-c5c2-43d5-846d-ca5f7c49f0e4"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8855), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8855), 0 },
                    { 5, new Guid("7b5f1baa-eb7c-48f6-aacf-89d6365e92b0"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8874), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8874), 0 },
                    { 6, new Guid("a94eaa41-47f7-4002-889a-64bf2e4241dd"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8885), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8885), 0 },
                    { 7, new Guid("eabb2ad3-e8f0-4392-95e4-35173cabbbde"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8904), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8904), 0 },
                    { 8, new Guid("9569f0ba-5b90-4608-a2af-7603ca3c4efa"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8923), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8923), 0 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Role for booker", "BOOKER" },
                    { 2, "Role for driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("c9376590-dc46-4765-8103-043f228044b5"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8739), 0, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8741), null, 1, 1, "Quach Dai Loi", 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8739), 0 },
                    { 2, new Guid("ac618d93-5553-4d80-8901-04537f43d30d"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8772), 0, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8773), null, 2, 1, "Do Trong Dat", 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8772), 0 },
                    { 3, new Guid("d9f2382b-fee7-4ada-a667-1b2c91870061"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8845), 0, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8847), null, 3, 1, "Nguyen Dang Khoa", 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8845), 0 },
                    { 4, new Guid("6e9c73ac-aa4c-4851-8d7d-547ae4a49018"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8863), 0, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8867), null, 4, 1, "Than Thanh Duy", 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8863), 0 },
                    { 6, new Guid("fc2d9b96-c44f-4f25-973f-a962e1cda690"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8894), 0, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8895), null, 6, 1, "Dat Do", 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8894), 0 },
                    { 7, new Guid("10acceca-0268-4fab-8d9b-8f27d8b0c271"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8913), 0, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8914), null, 7, 1, "Khoa Nguyen", 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8913), 0 },
                    { 8, new Guid("33712a73-fde4-4c23-877f-d80662aa1e5b"), new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8932), 0, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8933), null, 8, 1, "Thanh Duy", 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8932), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8941), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8942), 0, 2, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8951), 0, null, "+84837226239", 1, 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8951), 0, 2 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 5, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8959), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8959), 0, 2, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8965), 0, null, "+84377322919", 1, 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8965), 0, 2 },
                    { 7, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8972), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8972), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8980), 0, null, "+84377322919", 1, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8981), 0, 6, true },
                    { 9, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8988), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8988), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8994), 0, null, "+84914669962", 1, 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(8994), 0, 3 },
                    { 11, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9001), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9001), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9009), 0, null, "+84914669962", 1, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9009), 0, 7, true },
                    { 13, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9015), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9016), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9056), 0, null, "+84376826328", 1, 2, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9056), 0, 4 },
                    { 15, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9064), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9064), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9071), 0, null, "+84376826328", 1, 1, new DateTime(2022, 8, 29, 8, 9, 31, 951, DateTimeKind.Utc).AddTicks(9071), 0, 8, true });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_registration_role_id",
                table: "accounts",
                columns: new[] { "registration", "role_id" },
                unique: true,
                filter: "verified = true");

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
                name: "user_rooms");

            migrationBuilder.DropTable(
                name: "verified_codes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
