using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class ProductTroubleshoot2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Distributors_distributor_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_category_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_distributor_id",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "categoryid",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "distributorid",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryid",
                table: "Products",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_distributorid",
                table: "Products",
                column: "distributorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryid",
                table: "Products",
                column: "categoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Distributors_distributorid",
                table: "Products",
                column: "distributorid",
                principalTable: "Distributors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Distributors_distributorid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_categoryid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_distributorid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "categoryid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "distributorid",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_distributor_id",
                table: "Products",
                column: "distributor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Distributors_distributor_id",
                table: "Products",
                column: "distributor_id",
                principalTable: "Distributors",
                principalColumn: "id");
        }
    }
}
