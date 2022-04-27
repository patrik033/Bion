using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bion.Migrations
{
    public partial class updated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_MovieShowTimes_MovieShowTimeId",
                table: "TicketOrders");

            migrationBuilder.DropIndex(
                name: "IX_TicketOrders_MovieShowTimeId",
                table: "TicketOrders");

            migrationBuilder.DropColumn(
                name: "MovieShowTimeId",
                table: "TicketOrders");

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "TicketOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "TicketOrders");

            migrationBuilder.AddColumn<int>(
                name: "MovieShowTimeId",
                table: "TicketOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrders_MovieShowTimeId",
                table: "TicketOrders",
                column: "MovieShowTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_MovieShowTimes_MovieShowTimeId",
                table: "TicketOrders",
                column: "MovieShowTimeId",
                principalTable: "MovieShowTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
