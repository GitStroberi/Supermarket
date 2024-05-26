using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNamingConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Distributors_distributorid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "is_admin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "distributor_id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Users",
                newName: "IsAdmin");

            migrationBuilder.RenameIndex(
                name: "IX_Users_username",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "distributorid",
                table: "Products",
                newName: "DistributorId");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "barcode",
                table: "Products",
                newName: "Barcode");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Products",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Products_distributorid",
                table: "Products",
                newName: "IX_Products_DistributorId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryid",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_barcode",
                table: "Products",
                newName: "IX_Products_Barcode");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Distributors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Distributors",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Distributors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Distributors",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Distributors_name",
                table: "Distributors",
                newName: "IX_Distributors_Name");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Categories",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_name",
                table: "Categories",
                newName: "IX_Categories_Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Distributors_DistributorId",
                table: "Products",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Distributors_DistributorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsAdmin",
                table: "Users",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "Users",
                newName: "IX_Users_username");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "DistributorId",
                table: "Products",
                newName: "distributorid");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "categoryid");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "Products",
                newName: "barcode");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Products",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_Products_DistributorId",
                table: "Products",
                newName: "IX_Products_distributorid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_categoryid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                newName: "IX_Products_barcode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Distributors",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Distributors",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Distributors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Distributors",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_Distributors_Name",
                table: "Distributors",
                newName: "IX_Distributors_name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Categories",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                newName: "IX_Categories_name");

            migrationBuilder.AddColumn<bool>(
                name: "is_admin",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "distributor_id",
                table: "Products",
                type: "int",
                nullable: true);

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
    }
}
