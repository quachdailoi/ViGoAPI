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
                    { 1, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4390), 0, null, "Role for booker", "BOOKER", new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4390), 0 },
                    { 2, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4371), 0, null, "Role for driver", "DRIVER", new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4373), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("da0ef573-6a50-4b0e-a0bb-8cadcf8d3331"), new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4398), 0, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4424), null, 1, "Quach Dai Loi", 1, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4398), 0 },
                    { 2, new Guid("bd5b5d29-26e9-4f60-9502-4b71bae15ea4"), new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4489), 0, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4492), null, 1, "Olivier", 1, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4490), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4503), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4503), 0, 2, true },
                    { 2, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4512), 0, null, "+84837226239", 1, 2, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4513), 0, 2, true },
                    { 3, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4519), 0, null, "+84837226239", 1, 1, new DateTime(2022, 7, 26, 8, 10, 27, 876, DateTimeKind.Utc).AddTicks(4519), 0, 1, true }
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
