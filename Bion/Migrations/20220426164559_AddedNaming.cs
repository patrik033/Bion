using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bion.Migrations
{
    public partial class AddedNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Run Time In Hours",
                table: "Movies",
                newName: "RunTimeInHours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RunTimeInHours",
                table: "Movies",
                newName: "Run Time In Hours");
        }
    }
}
