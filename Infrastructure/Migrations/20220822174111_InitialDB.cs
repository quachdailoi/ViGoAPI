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
                    last_seen_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2022, 8, 21, 15, 53, 52, 202, DateTimeKind.Utc).AddTicks(3468)),
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

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
<<<<<<<< HEAD:Infrastructure/Migrations/20220821155352_InitialDB.cs
                values: new object[] { 1, new Guid("ad3f1ae5-f204-425e-9f51-fee81ce970b2"), new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(405), 0, null, "abcabc", true, 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(406), 0 });
========
                values: new object[] { 1, new Guid("542d042b-f2ae-411c-abdb-21afc4c2aa5a"), new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1050), 0, null, "abcabc", true, 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1052), 0 });
>>>>>>>> authen:Infrastructure/Migrations/20220822174111_InitialDB.cs

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
<<<<<<<< HEAD:Infrastructure/Migrations/20220821155352_InitialDB.cs
                    { 2, new Guid("3b00b1b0-07e4-4109-ab8a-99d1ecf22e82"), new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(455), 0, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(457), null, null, 1, "Olivier", 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(455), 0 },
                    { 3, new Guid("3ac596e5-8d6d-44f8-b9b3-cad7e6e99106"), new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(467), 0, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(469), null, null, 1, "Dat Do", 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(468), 0 }
========
                    { 2, new Guid("751b1dec-45db-432e-b27b-ea247c2e8272"), new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1089), 0, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1090), null, null, 1, "Do Trong Dat", 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1089), 0 },
                    { 3, new Guid("52465ff1-0249-4a1c-afc2-29d317a5407e"), new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1098), 0, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1099), null, null, 1, "Nguyen Dang Khoa", 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1098), 0 },
                    { 4, new Guid("6f52177e-4632-4c68-8f3c-091907be2288"), new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1106), 0, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1107), null, null, 1, "Than Thanh Duy", 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1106), 0 },
                    { 6, new Guid("f3e7f3ef-b4b0-4404-a0e2-1435590168d1"), new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1114), 0, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1118), null, null, 1, "Dat Do", 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1114), 0 },
                    { 7, new Guid("dee67ba6-f3b4-4797-a6d3-ad112b3491ad"), new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1126), 0, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1128), null, null, 1, "Khoa Nguyen", 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1127), 0 },
                    { 8, new Guid("666c9fdd-bef8-4b12-b5eb-344a1dcbabfa"), new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1134), 0, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1136), null, null, 1, "Thanh Duy", 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1135), 0 }
>>>>>>>> authen:Infrastructure/Migrations/20220822174111_InitialDB.cs
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
<<<<<<<< HEAD:Infrastructure/Migrations/20220821155352_InitialDB.cs
                values: new object[] { 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(480), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(480), 0, 2, true });
========
                values: new object[] { 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1143), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1143), 0, 2, true });
>>>>>>>> authen:Infrastructure/Migrations/20220822174111_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
<<<<<<<< HEAD:Infrastructure/Migrations/20220821155352_InitialDB.cs
                values: new object[] { 2, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(490), 0, null, "+84837226239", 1, 2, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(490), 0, 2 });
========
                values: new object[] { 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1151), 0, null, "+84837226239", 1, 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1152), 0, 2 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 5, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1158), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1158), 0, 2, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1163), 0, null, "+84377322919", 1, 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1163), 0, 2 },
                    { 7, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1169), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1169), 0, 6 }
                });
>>>>>>>> authen:Infrastructure/Migrations/20220822174111_InitialDB.cs

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
<<<<<<<< HEAD:Infrastructure/Migrations/20220821155352_InitialDB.cs
                    { 5, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(513), 0, null, "+84377322919", 1, 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(513), 0, 3, true },
                    { 6, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(522), 0, null, "trongdat2000@gmail.com", 0, 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(523), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[] { 1, new Guid("464fd474-f422-4643-ab22-70e3eeffd828"), new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(441), 0, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(444), null, 1, 1, "Quach Dai Loi", 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(442), 0 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 3, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(498), 0, null, "+848372262391", 1, 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(498), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 4, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(505), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 21, 15, 53, 52, 203, DateTimeKind.Utc).AddTicks(505), 0, 1 });
========
                    { 8, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1175), 0, null, "+84377322919", 1, 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1176), 0, 6, true },
                    { 9, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1181), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1181), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1187), 0, null, "+84914669962", 1, 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1187), 0, 3 },
                    { 11, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1192), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1193), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1199), 0, null, "+84914669962", 1, 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1199), 0, 7, true },
                    { 13, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1205), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1205), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1210), 0, null, "+84376826328", 1, 2, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1210), 0, 4 },
                    { 15, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1245), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1245), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1253), 0, null, "+84376826328", 1, 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1253), 0, 8, true });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[] { 1, new Guid("874929c4-78b6-4441-b91f-d69c093b452a"), new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1068), 0, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1078), null, 1, 1, "Quach Dai Loi", 1, new DateTime(2022, 8, 22, 17, 41, 10, 961, DateTimeKind.Utc).AddTicks(1068), 0 });
>>>>>>>> authen:Infrastructure/Migrations/20220822174111_InitialDB.cs

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
                name: "messages");

            migrationBuilder.DropTable(
                name: "user_rooms");

            migrationBuilder.DropTable(
                name: "verified_codes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
