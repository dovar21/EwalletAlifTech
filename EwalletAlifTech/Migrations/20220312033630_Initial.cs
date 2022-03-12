using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EwalletAlifTech.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "attestations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attestations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Key = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    full_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    attestation_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.UniqueConstraint("AK_users_Email", x => x.Email);
                    table.UniqueConstraint("AK_users_phone_number", x => x.phone_number);
                    table.UniqueConstraint("AK_users_UserName", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_users_attestations_attestation_id",
                        column: x => x.attestation_id,
                        principalTable: "attestations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    balance_limit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    balance_limit_updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    account_type = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                    table.UniqueConstraint("AK_accounts_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_accounts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    from_account_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    created_by_user_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    to_account_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    account_balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_from_account_id",
                        column: x => x.from_account_id,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_to_account_id",
                        column: x => x.to_account_id,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_users_created_by_user_id",
                        column: x => x.created_by_user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "attestations",
                columns: new[] { "Id", "Code", "created_at", "Name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("5ee95dcb-a078-11e8-904b-b06ebfbfa234"), "NOT_IDENTIFIED", new DateTime(2022, 3, 12, 8, 36, 29, 778, DateTimeKind.Local).AddTicks(3469), "Неидентифицированный", new DateTime(2022, 3, 12, 8, 36, 29, 778, DateTimeKind.Local).AddTicks(4160) },
                    { new Guid("5ee95dcb-a078-11e8-904b-b06ebfbfa235"), "IDENTIFIED", new DateTime(2022, 3, 12, 8, 36, 29, 778, DateTimeKind.Local).AddTicks(4918), "Идентифицированный", new DateTime(2022, 3, 12, 8, 36, 29, 778, DateTimeKind.Local).AddTicks(4927) }
                });

            migrationBuilder.InsertData(
                table: "settings",
                columns: new[] { "Id", "created_at", "Key", "updated_at", "Value" },
                values: new object[,]
                {
                    { new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d121"), new DateTime(2022, 3, 12, 8, 36, 29, 786, DateTimeKind.Local).AddTicks(5534), "NOT_IDENTIFIED_USER_MAX_BALANCE", new DateTime(2022, 3, 12, 8, 36, 29, 786, DateTimeKind.Local).AddTicks(6988), "10000" },
                    { new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d122"), new DateTime(2022, 3, 12, 8, 36, 29, 786, DateTimeKind.Local).AddTicks(7703), "IDENTIFIED_USER_MAX_BALANCE", new DateTime(2022, 3, 12, 8, 36, 29, 786, DateTimeKind.Local).AddTicks(7713), "100000" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "attestation_id", "created_at", "Email", "full_name", "Hash", "is_active", "Password", "phone_number", "updated_at", "UserName" },
                values: new object[] { new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d112"), new Guid("5ee95dcb-a078-11e8-904b-b06ebfbfa234"), new DateTime(2022, 3, 12, 8, 36, 29, 766, DateTimeKind.Local).AddTicks(4909), "user2@gmail.com", "User2", "", false, "user2", "992938640103", new DateTime(2022, 3, 12, 8, 36, 29, 766, DateTimeKind.Local).AddTicks(4920), "user2" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "attestation_id", "created_at", "Email", "full_name", "Hash", "is_active", "Password", "phone_number", "updated_at", "UserName" },
                values: new object[] { new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d111"), new Guid("5ee95dcb-a078-11e8-904b-b06ebfbfa235"), new DateTime(2022, 3, 12, 8, 36, 29, 764, DateTimeKind.Local).AddTicks(9566), "user1@gmail.com", "User1", "", false, "user1", "992938640102", new DateTime(2022, 3, 12, 8, 36, 29, 766, DateTimeKind.Local).AddTicks(4143), "user1" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "attestation_id", "created_at", "Email", "full_name", "Hash", "is_active", "Password", "phone_number", "updated_at", "UserName" },
                values: new object[] { new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d113"), new Guid("5ee95dcb-a078-11e8-904b-b06ebfbfa235"), new DateTime(2022, 3, 12, 8, 36, 29, 766, DateTimeKind.Local).AddTicks(4929), "user3@gmail.com", "User3", "", false, "user3", "992938640104", new DateTime(2022, 3, 12, 8, 36, 29, 766, DateTimeKind.Local).AddTicks(4931), "user3" });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "Id", "account_type", "Balance", "balance_limit", "balance_limit_updated_at", "created_at", "is_active", "Number", "updated_at", "user_id" },
                values: new object[] { new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d114"), 1, 0m, 10000m, new DateTime(2022, 3, 12, 8, 36, 29, 775, DateTimeKind.Local).AddTicks(9414), new DateTime(2022, 3, 12, 8, 36, 29, 775, DateTimeKind.Local).AddTicks(9406), true, "20202000000000002", new DateTime(2022, 3, 12, 8, 36, 29, 775, DateTimeKind.Local).AddTicks(9409), new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d112") });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "Id", "account_type", "Balance", "balance_limit", "balance_limit_updated_at", "created_at", "is_active", "Number", "updated_at", "user_id" },
                values: new object[] { new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d111"), 1, 80000m, 20000m, new DateTime(2022, 3, 12, 8, 36, 29, 775, DateTimeKind.Local).AddTicks(9334), new DateTime(2022, 3, 12, 8, 36, 29, 774, DateTimeKind.Local).AddTicks(7856), true, "20202000000000001", new DateTime(2022, 3, 12, 8, 36, 29, 774, DateTimeKind.Local).AddTicks(8476), new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d111") });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "Id", "account_type", "Balance", "balance_limit", "balance_limit_updated_at", "created_at", "is_active", "Number", "updated_at", "user_id" },
                values: new object[] { new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d115"), 1, 10000m, 90000m, new DateTime(2022, 3, 12, 8, 36, 29, 775, DateTimeKind.Local).AddTicks(9435), new DateTime(2022, 3, 12, 8, 36, 29, 775, DateTimeKind.Local).AddTicks(9421), true, "20202000000000003", new DateTime(2022, 3, 12, 8, 36, 29, 775, DateTimeKind.Local).AddTicks(9423), new Guid("1ca06b7b-13fa-5952-827b-2fef6e40d113") });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_created_by_user_id",
                table: "transactions",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_from_account_id",
                table: "transactions",
                column: "from_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_to_account_id",
                table: "transactions",
                column: "to_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_attestation_id",
                table: "users",
                column: "attestation_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "attestations");
        }
    }
}
