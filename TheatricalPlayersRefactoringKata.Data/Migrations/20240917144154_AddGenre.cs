using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatricalPlayersRefactoringKata.Data.Migrations
{
    public partial class AddGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GenreId",
                table: "Plays",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Plays_GenreId",
                table: "Plays",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plays_Genres_GenreId",
                table: "Plays",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plays_Genres_GenreId",
                table: "Plays");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Plays_GenreId",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Plays");
        }
    }
}
