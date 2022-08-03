using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoInventory.Data.Migrations
{
    public partial class RestoreForProductAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductEntries_ProductEntryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductEntries");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductEntryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductEntryId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductEntryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntries", x => x.Id);
                });

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
    }
}
