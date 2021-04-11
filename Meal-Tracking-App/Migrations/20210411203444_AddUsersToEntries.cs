using Microsoft.EntityFrameworkCore.Migrations;

namespace Meal_Tracking_App.Migrations
{
    public partial class AddUsersToEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Entries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Entries");
        }
    }
}
