using Microsoft.EntityFrameworkCore.Migrations;

namespace Gym.Migrations
{
    public partial class ActivityCompleteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "ActivityPlayer");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Activities",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Activities");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "ActivityPlayer",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
