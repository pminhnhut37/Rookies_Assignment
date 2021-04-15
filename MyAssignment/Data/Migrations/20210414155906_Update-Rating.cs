using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAssignment.Data.Migrations
{
    public partial class UpdateRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Ratings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
