using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sections_Zoos_ZooId",
                table: "sections");

            migrationBuilder.DropIndex(
                name: "IX_sections_ZooId",
                table: "sections");

            migrationBuilder.RenameColumn(
                name: "SectionsId",
                table: "Tickets",
                newName: "TicketCount");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "sections",
                newName: "Captions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Zoos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "sections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "sections");

            migrationBuilder.RenameColumn(
                name: "TicketCount",
                table: "Tickets",
                newName: "SectionsId");

            migrationBuilder.RenameColumn(
                name: "Captions",
                table: "sections",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Zoos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_sections_ZooId",
                table: "sections",
                column: "ZooId");

            migrationBuilder.AddForeignKey(
                name: "FK_sections_Zoos_ZooId",
                table: "sections",
                column: "ZooId",
                principalTable: "Zoos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
