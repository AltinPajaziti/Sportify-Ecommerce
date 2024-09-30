using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class relationchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "basket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "usersid",
                table: "basket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_basket_usersid",
                table: "basket",
                column: "usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_basket_users_usersid",
                table: "basket",
                column: "usersid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basket_users_usersid",
                table: "basket");

            migrationBuilder.DropIndex(
                name: "IX_basket_usersid",
                table: "basket");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "basket");

            migrationBuilder.DropColumn(
                name: "usersid",
                table: "basket");
        }
    }
}
