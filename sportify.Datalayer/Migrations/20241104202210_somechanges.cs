using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProducts_products_productid",
                table: "FavoriteProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProducts_users_Userid",
                table: "FavoriteProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProducts",
                table: "FavoriteProducts");

            migrationBuilder.RenameTable(
                name: "FavoriteProducts",
                newName: "favoriteProducts");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProducts_productid",
                table: "favoriteProducts",
                newName: "IX_favoriteProducts_productid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_favoriteProducts",
                table: "favoriteProducts",
                columns: new[] { "Userid", "productid" });

            migrationBuilder.AddForeignKey(
                name: "FK_favoriteProducts_products_productid",
                table: "favoriteProducts",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favoriteProducts_users_Userid",
                table: "favoriteProducts",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favoriteProducts_products_productid",
                table: "favoriteProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_favoriteProducts_users_Userid",
                table: "favoriteProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_favoriteProducts",
                table: "favoriteProducts");

            migrationBuilder.RenameTable(
                name: "favoriteProducts",
                newName: "FavoriteProducts");

            migrationBuilder.RenameIndex(
                name: "IX_favoriteProducts_productid",
                table: "FavoriteProducts",
                newName: "IX_FavoriteProducts_productid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProducts",
                table: "FavoriteProducts",
                columns: new[] { "Userid", "productid" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProducts_products_productid",
                table: "FavoriteProducts",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProducts_users_Userid",
                table: "FavoriteProducts",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
