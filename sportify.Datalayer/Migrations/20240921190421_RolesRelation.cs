using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class RolesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Roleid",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_Roleid",
                table: "users",
                column: "Roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Roles_Roleid",
                table: "users",
                column: "Roleid",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Roles_Roleid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Roleid",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Roleid",
                table: "users");
        }
    }
}
