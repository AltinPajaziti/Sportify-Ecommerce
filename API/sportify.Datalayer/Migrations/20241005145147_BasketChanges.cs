using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class BasketChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "BasketProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "BasketProduct");
        }
    }
}
