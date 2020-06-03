using Microsoft.EntityFrameworkCore.Migrations;

namespace Market.Migrations
{
    public partial class AddTrash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrashId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trash",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trash", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TrashId",
                table: "Products",
                column: "TrashId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Trash_TrashId",
                table: "Products",
                column: "TrashId",
                principalTable: "Trash",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Trash_TrashId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Trash");

            migrationBuilder.DropIndex(
                name: "IX_Products_TrashId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TrashId",
                table: "Products");
        }
    }
}
