using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graphApi.Migrations
{
    /// <inheritdoc />
    public partial class MenuPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Page",
                type: "int",
                nullable: true
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Page_Menu_MenuId", table: "Page");

            migrationBuilder.DropIndex(name: "IX_Page_MenuId", table: "Page");

            migrationBuilder.DropColumn(name: "MenuId", table: "Page");
        }
    }
}
