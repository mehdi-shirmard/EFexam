using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Zoos_ZooId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "sections");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_ZooId",
                table: "sections",
                newName: "IX_sections_ZooId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sections",
                table: "sections",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SectionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_sections_Zoos_ZooId",
                table: "sections",
                column: "ZooId",
                principalTable: "Zoos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sections_Zoos_ZooId",
                table: "sections");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sections",
                table: "sections");

            migrationBuilder.RenameTable(
                name: "sections",
                newName: "Sections");

            migrationBuilder.RenameIndex(
                name: "IX_sections_ZooId",
                table: "Sections",
                newName: "IX_Sections_ZooId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Zoos_ZooId",
                table: "Sections",
                column: "ZooId",
                principalTable: "Zoos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
