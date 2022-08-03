using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoInventory.Data.Migrations
{
    public partial class HandlingProductEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntryDetail");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<int>(
                name: "ProductEntryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductEntryId",
                table: "Products",
                column: "ProductEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductEntries_ProductEntryId",
                table: "Products",
                column: "ProductEntryId",
                principalTable: "ProductEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductEntries_ProductEntryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductEntryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductEntryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Stock");

            migrationBuilder.CreateTable(
                name: "ProductEntryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsEntryId = table.Column<int>(type: "int", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEntryDetail_ProductEntries_ProductsEntryId",
                        column: x => x.ProductsEntryId,
                        principalTable: "ProductEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntryDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntryDetail_ProductId",
                table: "ProductEntryDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntryDetail_ProductsEntryId",
                table: "ProductEntryDetail",
                column: "ProductsEntryId");
        }
    }
}
