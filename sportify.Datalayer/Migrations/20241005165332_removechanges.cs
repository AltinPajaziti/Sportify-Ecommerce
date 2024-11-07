using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class removechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Roles_RoliID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_RoliID",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RoliID",
                table: "users");

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

            migrationBuilder.AddColumn<int>(
                name: "RoliID",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_RoliID",
                table: "users",
                column: "RoliID");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Roles_RoliID",
                table: "users",
                column: "RoliID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
