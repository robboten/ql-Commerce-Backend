using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graphApi.Migrations
{
    /// <inheritdoc />
    public partial class cartItemMerchantVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Merchandise_MerchandiseId",
                table: "CartItem"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_Merchandise_MerchandiseId",
                table: "SelectedOptions"
            );

            migrationBuilder.DropTable(name: "Merchandise");

            migrationBuilder.DropIndex(
                name: "IX_SelectedOptions_MerchandiseId",
                table: "SelectedOptions"
            );

            migrationBuilder.DropColumn(name: "MerchandiseId", table: "SelectedOptions");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ProductVariant_MerchandiseId",
                table: "CartItem",
                column: "MerchandiseId",
                principalTable: "ProductVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ProductVariant_MerchandiseId",
                table: "CartItem"
            );

            migrationBuilder.AddColumn<int>(
                name: "MerchandiseId",
                table: "SelectedOptions",
                type: "int",
                nullable: true
            );

            migrationBuilder.CreateTable(
                name: "Merchandise",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchandise_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_SelectedOptions_MerchandiseId",
                table: "SelectedOptions",
                column: "MerchandiseId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Merchandise_ProductId",
                table: "Merchandise",
                column: "ProductId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Merchandise_MerchandiseId",
                table: "CartItem",
                column: "MerchandiseId",
                principalTable: "Merchandise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_Merchandise_MerchandiseId",
                table: "SelectedOptions",
                column: "MerchandiseId",
                principalTable: "Merchandise",
                principalColumn: "Id"
            );
        }
    }
}
