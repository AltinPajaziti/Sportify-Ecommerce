using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrationn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "PasswordHAsh");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "products",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "Pershkrimi",
                table: "products",
                newName: "Insertedby");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "contacts",
                newName: "LastModified");

            migrationBuilder.AddColumn<string>(
                name: "Insertedby",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModified",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Insertedby",
                table: "contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Insertedby",
                table: "category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModified",
                table: "category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Insertedby",
                table: "basket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModified",
                table: "basket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insertedby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropColumn(
                name: "Insertedby",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Insertedby",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "Insertedby",
                table: "category");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "category");

            migrationBuilder.DropColumn(
                name: "Insertedby",
                table: "basket");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "basket");

            migrationBuilder.RenameColumn(
                name: "PasswordHAsh",
                table: "users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "products",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Insertedby",
                table: "products",
                newName: "Pershkrimi");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "contacts",
                newName: "Adress");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "products",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
