using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graphApi.Migrations
{
    /// <inheritdoc />
    public partial class menuitems_productcreatedat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Page_Menu_MenuId", table: "Page");

            migrationBuilder.DropIndex(name: "IX_Page_MenuId", table: "Page");

            migrationBuilder.DropColumn(name: "MenuId", table: "Page");

            migrationBuilder.DropColumn(name: "Path", table: "Menu");

            migrationBuilder.RenameColumn(name: "Title", table: "Menu", newName: "Handle");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "MenuItems");

            migrationBuilder.DropColumn(name: "CreatedAt", table: "Product");

            migrationBuilder.RenameColumn(name: "Handle", table: "Menu", newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Page",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.CreateIndex(name: "IX_Page_MenuId", table: "Page", column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Menu_MenuId",
                table: "Page",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id"
            );
        }
    }
}
