using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graphApi.Migrations
{
    /// <inheritdoc />
    public partial class cartkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MerchandiseId",
                table: "SelectedOptions",
                type: "int",
                nullable: true
            );

            migrationBuilder.CreateTable(
                name: "Cost",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubtotalAmountId = table.Column<int>(type: "int", nullable: true),
                    TotalAmountId = table.Column<int>(type: "int", nullable: true),
                    TotalTaxAmountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cost_Money_SubtotalAmountId",
                        column: x => x.SubtotalAmountId,
                        principalTable: "Money",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Cost_Money_TotalAmountId",
                        column: x => x.TotalAmountId,
                        principalTable: "Money",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Cost_Money_TotalTaxAmountId",
                        column: x => x.TotalTaxAmountId,
                        principalTable: "Money",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Merchandise",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckoutUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostId = table.Column<int>(type: "int", nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Cost_CostId",
                        column: x => x.CostId,
                        principalTable: "Cost",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CostId = table.Column<int>(type: "int", nullable: false),
                    MerchandiseId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_CartItem_Cost_CostId",
                        column: x => x.CostId,
                        principalTable: "Cost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_CartItem_Merchandise_MerchandiseId",
                        column: x => x.MerchandiseId,
                        principalTable: "Merchandise",
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

            migrationBuilder.CreateIndex(name: "IX_Cart_CostId", table: "Cart", column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CostId",
                table: "CartItem",
                column: "CostId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_MerchandiseId",
                table: "CartItem",
                column: "MerchandiseId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cost_SubtotalAmountId",
                table: "Cost",
                column: "SubtotalAmountId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cost_TotalAmountId",
                table: "Cost",
                column: "TotalAmountId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cost_TotalTaxAmountId",
                table: "Cost",
                column: "TotalTaxAmountId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Merchandise_ProductId",
                table: "Merchandise",
                column: "ProductId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_Merchandise_MerchandiseId",
                table: "SelectedOptions",
                column: "MerchandiseId",
                principalTable: "Merchandise",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_Merchandise_MerchandiseId",
                table: "SelectedOptions"
            );

            migrationBuilder.DropTable(name: "CartItem");

            migrationBuilder.DropTable(name: "Cart");

            migrationBuilder.DropTable(name: "Merchandise");

            migrationBuilder.DropTable(name: "Cost");

            migrationBuilder.DropIndex(
                name: "IX_SelectedOptions_MerchandiseId",
                table: "SelectedOptions"
            );

            migrationBuilder.DropColumn(name: "MerchandiseId", table: "SelectedOptions");
        }
    }
}
