using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDLMigration.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesTable",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesTable", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ItemsTable",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsTable", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItemJoinedTable",
                columns: table => new
                {
                    CategoryItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemJoinedTable", x => x.CategoryItemId);
                    table.ForeignKey(
                        name: "FK_CategoryItemJoinedTable_CategoriesTable_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesTable",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItemJoinedTable_ItemsTable_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemsTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItemJoinedTable_CategoryId",
                table: "CategoryItemJoinedTable",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItemJoinedTable_ItemId",
                table: "CategoryItemJoinedTable",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItemJoinedTable");

            migrationBuilder.DropTable(
                name: "CategoriesTable");

            migrationBuilder.DropTable(
                name: "ItemsTable");
        }
    }
}
