using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graphApi.Migrations
{
    /// <inheritdoc />
    public partial class ProductVariantsArray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_SelectedOptions_SelectedOptionsId",
                table: "ProductVariant"
            );

            migrationBuilder.DropIndex(
                name: "IX_ProductVariant_SelectedOptionsId",
                table: "ProductVariant"
            );

            migrationBuilder.DropColumn(name: "SelectedOptionsId", table: "ProductVariant");

            migrationBuilder.AddColumn<int>(
                name: "ProductVariantId",
                table: "SelectedOptions",
                type: "int",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_SelectedOptions_ProductVariantId",
                table: "SelectedOptions",
                column: "ProductVariantId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_ProductVariant_ProductVariantId",
                table: "SelectedOptions",
                column: "ProductVariantId",
                principalTable: "ProductVariant",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_ProductVariant_ProductVariantId",
                table: "SelectedOptions"
            );

            migrationBuilder.DropIndex(
                name: "IX_SelectedOptions_ProductVariantId",
                table: "SelectedOptions"
            );

            migrationBuilder.DropColumn(name: "ProductVariantId", table: "SelectedOptions");

            migrationBuilder.AddColumn<int>(
                name: "SelectedOptionsId",
                table: "ProductVariant",
                type: "int",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_SelectedOptionsId",
                table: "ProductVariant",
                column: "SelectedOptionsId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_SelectedOptions_SelectedOptionsId",
                table: "ProductVariant",
                column: "SelectedOptionsId",
                principalTable: "SelectedOptions",
                principalColumn: "Id"
            );
        }
    }
}
