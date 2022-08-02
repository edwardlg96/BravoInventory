using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoInventory.Data.Migrations
{
    public partial class ProductNameField_To_ProductDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Name");
        }
    }
}
