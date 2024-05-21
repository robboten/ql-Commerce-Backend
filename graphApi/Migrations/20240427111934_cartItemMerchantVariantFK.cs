﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graphApi.Migrations
{
    /// <inheritdoc />
    public partial class cartItemMerchantVariantFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_Product_ProductId",
                table: "ProductVariant"
            );

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductVariant",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_Product_ProductId",
                table: "ProductVariant",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_Product_ProductId",
                table: "ProductVariant"
            );

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductVariant",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_Product_ProductId",
                table: "ProductVariant",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id"
            );
        }
    }
}
