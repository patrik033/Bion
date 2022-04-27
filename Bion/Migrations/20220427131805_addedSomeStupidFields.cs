using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bion.Migrations
{
    public partial class addedSomeStupidFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalongName",
                table: "TicketOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "TicketOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalongName",
                table: "TicketOrders");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "TicketOrders");
        }
    }
}
