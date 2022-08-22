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
                    role_id = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[] { 1, new Guid("3cc61659-a3fc-40f4-a768-692870378e42"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3627), 0, null, "abcabc", true, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3629), 0 });

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
                    { 2, new Guid("95e80e41-94fe-48b1-b12d-1a00fb39f5ab"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3655), 0, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3657), null, null, 1, "Do Trong Dat", 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3655), 0 },
                    { 3, new Guid("b803a031-d60e-441d-84a1-7d6134430f34"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3664), 0, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3674), null, null, 1, "Nguyen Dang Khoa", 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3664), 0 },
                    { 4, new Guid("854864b7-a9dc-4914-83c3-7a159093d221"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3684), 0, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3686), null, null, 1, "Than Thanh Duy", 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3685), 0 },
                    { 5, new Guid("7222de4b-69df-42f9-8113-ecbbdda0c673"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3692), 0, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3693), null, null, 1, "Loi Quach", 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3692), 0 },
                    { 6, new Guid("7c02d793-97c3-401a-a31a-49f6cea017e0"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3701), 0, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3702), null, null, 1, "Dat Do", 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3701), 0 },
                    { 7, new Guid("eacb9017-7792-4b03-9ab8-aa510ba9f404"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3708), 0, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3712), null, null, 1, "Khoa Nguyen", 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3709), 0 },
                    { 8, new Guid("d8d1d4a2-1031-4e62-afc4-61d484171018"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3718), 0, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3719), null, null, 1, "Thanh Duy", 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3718), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3725), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3726), 0, 2, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3734), 0, null, "+84837226239", 1, 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3734), 0, 2 },
                    { 3, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3740), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3740), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3746), 0, null, "+84837226239", 1, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3746), 0, 5, true },
                    { 5, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3752), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3752), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3759), 0, null, "+84377322919", 1, 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3759), 0, 2 },
                    { 7, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3765), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3765), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3770), 0, null, "+84377322919", 1, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3771), 0, 6, true },
                    { 9, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3776), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3776), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3783), 0, null, "+84914669962", 1, 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3783), 0, 3 },
                    { 11, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3789), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3789), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3829), 0, null, "+84914669962", 1, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3829), 0, 7, true },
                    { 13, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3835), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3836), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3841), 0, null, "+84376826328", 1, 2, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3841), 0, 4 },
                    { 15, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3847), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3847), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3853), 0, null, "+84376826328", 1, 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3853), 0, 8, true });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[] { 1, new Guid("3dc6f0ed-7be3-49b2-ae19-e0215c459235"), new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3643), 0, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3644), null, 1, 1, "Quach Dai Loi", 1, new DateTime(2022, 8, 22, 9, 41, 27, 838, DateTimeKind.Utc).AddTicks(3643), 0 });

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
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

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
                name: "verified_codes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
