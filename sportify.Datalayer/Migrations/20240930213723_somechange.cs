using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class somechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "basket");

            migrationBuilder.DropColumn(
                name: "QTY",
                table: "basket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "basket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QTY",
                table: "basket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
