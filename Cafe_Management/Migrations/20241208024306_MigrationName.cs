using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafe_Management.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMenuDetail");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductRecipe",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductRecipe",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ProductRecipe",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductRecipe");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductRecipe");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ProductRecipe");

            migrationBuilder.CreateTable(
                name: "MenuMenuDetail",
                columns: table => new
                {
                    MenuDetailSetup_ID = table.Column<int>(type: "int", nullable: false),
                    Menu_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMenuDetail", x => new { x.MenuDetailSetup_ID, x.Menu_ID });
                    table.ForeignKey(
                        name: "FK_MenuMenuDetail_Menu_Menu_ID",
                        column: x => x.Menu_ID,
                        principalTable: "Menu",
                        principalColumn: "Menu_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuMenuDetail_MenuDetail_MenuDetailSetup_ID",
                        column: x => x.MenuDetailSetup_ID,
                        principalTable: "MenuDetail",
                        principalColumn: "Setup_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenuDetail_Menu_ID",
                table: "MenuMenuDetail",
                column: "Menu_ID");
        }
    }
}
