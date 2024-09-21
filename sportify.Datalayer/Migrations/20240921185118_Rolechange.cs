using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class Rolechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Insertedby",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Roles",
                newName: "RoleName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Roles",
                newName: "User");

            migrationBuilder.AddColumn<string>(
                name: "Admin",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Insertedby",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModified",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
