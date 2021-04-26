using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAssignment.Data.Migrations
{
    public partial class updateProductagian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryIDCate",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryIDCate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryIDCate",
                table: "Products");

            migrationBuilder.AlterColumn<float>(
                name: "RateStar",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IDCate",
                table: "Products",
                column: "IDCate");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_IDCate",
                table: "Products",
                column: "IDCate",
                principalTable: "Categories",
                principalColumn: "IDCate",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_IDCate",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IDCate",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "RateStar",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "CategoryIDCate",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryIDCate",
                table: "Products",
                column: "CategoryIDCate");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryIDCate",
                table: "Products",
                column: "CategoryIDCate",
                principalTable: "Categories",
                principalColumn: "IDCate",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
