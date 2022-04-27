using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bion.Migrations
{
    public partial class updatedSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "MovieShowTimes");

            migrationBuilder.RenameColumn(
                name: "MovieScreeningTime",
                table: "MovieShowTimes",
                newName: "Run Time");

            migrationBuilder.RenameColumn(
                name: "RunTimeInHours",
                table: "Movies",
                newName: "Run Time In Hours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Run Time",
                table: "MovieShowTimes",
                newName: "MovieScreeningTime");

            migrationBuilder.RenameColumn(
                name: "Run Time In Hours",
                table: "Movies",
                newName: "RunTimeInHours");

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "MovieShowTimes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "MovieShowTimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TicketPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "MovieShowTimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "TicketPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "MovieShowTimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "TicketPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "MovieShowTimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "TicketPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "MovieShowTimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "TicketPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "MovieShowTimes",
                keyColumn: "Id",
                keyValue: 6,
                column: "TicketPrice",
                value: 100m);
        }
    }
}
