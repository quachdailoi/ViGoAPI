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
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
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
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    registration = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
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
                    AccountId = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verified_codes", x => x.id);
                    table.ForeignKey(
                        name: "FK_verified_codes_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "description", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7017), 0, null, "Role for booker", "BOOKER", new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7017), 0 },
                    { 2, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(6992), 0, null, "Role for driver", "DRIVER", new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(6994), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("2aa60a5f-2058-4026-9896-d47a79f81393"), new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7026), 0, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7063), null, 1, "Quach Dai Loi", 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7026), 0 },
                    { 2, new Guid("eda460a0-9bda-49cb-8ab7-7306ddcbf657"), new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7075), 0, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7077), null, 1, "Olivier", 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7076), 0 },
                    { 3, new Guid("87fdf729-4c30-41f4-989d-fe5c909c8a87"), new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7085), 0, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7086), null, 1, "Dat Do", 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7085), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7096), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7096), 0, 2, true },
                    { 2, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7109), 0, null, "+84837226239", 1, 2, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7109), 0, 2, true },
                    { 3, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7116), 0, null, "+84837226239", 1, 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7116), 0, 1, true },
                    { 4, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7123), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7123), 0, 1, true },
                    { 5, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7130), 0, null, "+84377322919", 1, 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7130), 0, 3, true },
                    { 6, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7139), 0, null, "trongdat2000@gmail.com", 0, 1, new DateTime(2022, 8, 4, 14, 19, 47, 445, DateTimeKind.Utc).AddTicks(7140), 0, 3, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_registration_role_id",
                table: "accounts",
                columns: new[] { "registration", "role_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_role_id",
                table: "accounts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_description",
                table: "roles",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_verified_codes_AccountId",
                table: "verified_codes",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "verified_codes");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
