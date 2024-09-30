using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class RelationsChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketProduct",
                columns: table => new
                {
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    Productid = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    Insertedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProduct", x => new { x.BasketId, x.Productid });
                    table.ForeignKey(
                        name: "FK_BasketProduct_basket_BasketId",
                        column: x => x.BasketId,
                        principalTable: "basket",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProduct_products_Productid",
                        column: x => x.Productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketProduct_Productid",
                table: "BasketProduct",
                column: "Productid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProduct");
        }
    }
}
