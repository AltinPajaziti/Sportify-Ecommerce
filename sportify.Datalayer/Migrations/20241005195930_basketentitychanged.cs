using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class basketentitychanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Insertedby",
                table: "BasketProduct");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "BasketProduct");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "BasketProduct",
                newName: "BasketProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BasketProductID",
                table: "BasketProduct",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "Insertedby",
                table: "BasketProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModified",
                table: "BasketProduct",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
