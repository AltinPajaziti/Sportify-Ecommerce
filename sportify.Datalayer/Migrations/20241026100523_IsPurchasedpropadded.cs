using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class IsPurchasedpropadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_products_ProductId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "stock");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_ProductId",
                table: "stock",
                newName: "IX_stock_ProductId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPurchased",
                table: "BasketProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_stock",
                table: "stock",
                column: "Stockid");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_products_ProductId",
                table: "stock",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_products_ProductId",
                table: "stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stock",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "IsPurchased",
                table: "BasketProduct");

            migrationBuilder.RenameTable(
                name: "stock",
                newName: "Stock");

            migrationBuilder.RenameIndex(
                name: "IX_stock_ProductId",
                table: "Stock",
                newName: "IX_Stock_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Stockid");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_products_ProductId",
                table: "Stock",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
