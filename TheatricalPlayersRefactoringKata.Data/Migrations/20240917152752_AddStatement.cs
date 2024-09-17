using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatricalPlayersRefactoringKata.Data.Migrations
{
    public partial class AddStatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("428c7836-71db-4a71-b0a7-23e4cfe1323a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b770c8e2-cc35-45db-849a-c330e1a009ad"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f69d02bb-ba41-4b5a-9dae-6bbea7e07b93"));

            migrationBuilder.AddColumn<Guid>(
                name: "StatementId",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TotalCost = table.Column<decimal>(type: "TEXT", nullable: true),
                    Credits = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statements_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PerformanceCost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StatementId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PerformanceId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceCost_Performances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Performances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PerformanceCost_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("0c3da678-b058-4d7e-bc57-c453e745f5ad"), new DateTime(2024, 9, 17, 12, 27, 52, 706, DateTimeKind.Local).AddTicks(3877), null, "comedy", new DateTime(2024, 9, 17, 12, 27, 52, 706, DateTimeKind.Local).AddTicks(3893) });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("b0728ae8-7059-4fff-a97e-036365916d68"), new DateTime(2024, 9, 17, 12, 27, 52, 706, DateTimeKind.Local).AddTicks(3896), null, "tragedy", new DateTime(2024, 9, 17, 12, 27, 52, 706, DateTimeKind.Local).AddTicks(3896) });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("fe4e5fc6-1800-4218-835c-0e0ed6bb714c"), new DateTime(2024, 9, 17, 12, 27, 52, 706, DateTimeKind.Local).AddTicks(3897), null, "history", new DateTime(2024, 9, 17, 12, 27, 52, 706, DateTimeKind.Local).AddTicks(3897) });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StatementId",
                table: "Invoices",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceCost_PerformanceId",
                table: "PerformanceCost",
                column: "PerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceCost_StatementId",
                table: "PerformanceCost",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_CustomerId",
                table: "Statements",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Statements_StatementId",
                table: "Invoices",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Statements_StatementId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "PerformanceCost");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_StatementId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0c3da678-b058-4d7e-bc57-c453e745f5ad"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b0728ae8-7059-4fff-a97e-036365916d68"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fe4e5fc6-1800-4218-835c-0e0ed6bb714c"));

            migrationBuilder.DropColumn(
                name: "StatementId",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("428c7836-71db-4a71-b0a7-23e4cfe1323a"), new DateTime(2024, 9, 17, 11, 41, 53, 922, DateTimeKind.Local).AddTicks(4137), null, "comedy", new DateTime(2024, 9, 17, 11, 41, 53, 922, DateTimeKind.Local).AddTicks(4147) });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("b770c8e2-cc35-45db-849a-c330e1a009ad"), new DateTime(2024, 9, 17, 11, 41, 53, 922, DateTimeKind.Local).AddTicks(4150), null, "history", new DateTime(2024, 9, 17, 11, 41, 53, 922, DateTimeKind.Local).AddTicks(4150) });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("f69d02bb-ba41-4b5a-9dae-6bbea7e07b93"), new DateTime(2024, 9, 17, 11, 41, 53, 922, DateTimeKind.Local).AddTicks(4149), null, "tragedy", new DateTime(2024, 9, 17, 11, 41, 53, 922, DateTimeKind.Local).AddTicks(4149) });
        }
    }
}
