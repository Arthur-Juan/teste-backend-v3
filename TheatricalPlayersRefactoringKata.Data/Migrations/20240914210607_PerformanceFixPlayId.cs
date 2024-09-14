using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatricalPlayersRefactoringKata.Data.Migrations
{
    public partial class PerformanceFixPlayId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayId",
                table: "Performances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayId",
                table: "Performances",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
