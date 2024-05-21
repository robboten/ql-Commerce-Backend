using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graphApi.Migrations
{
    /// <inheritdoc />
    public partial class ProductPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Product_PriceId",
                table: "Product",
                column: "PriceId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Money_PriceId",
                table: "Product",
                column: "PriceId",
                principalTable: "Money",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Product_Money_PriceId", table: "Product");

            migrationBuilder.DropTable(name: "Money");

            migrationBuilder.DropIndex(name: "IX_Product_PriceId", table: "Product");

            migrationBuilder.DropColumn(name: "PriceId", table: "Product");
        }
    }
}
