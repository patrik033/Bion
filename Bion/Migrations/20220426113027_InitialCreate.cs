using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bion.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RunTimeInHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieShowTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieScreeningTime = table.Column<double>(type: "float", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    MaxNumberSeats = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShowTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieShowTimes_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieShowTimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "CinemaName" },
                values: new object[,]
                {
                    { 1, "Poor man cinema" },
                    { 2, "Fancy Cinema" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "RunTimeInHours", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Dia Hard" },
                    { 2, 3, "Lord Of The Rings II" }
                });

            migrationBuilder.InsertData(
                table: "MovieShowTimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaId", "MaxNumberSeats", "MovieId", "MovieScreeningTime", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 50, 1, 50, 1, 13.0, 100m },
                    { 2, 50, 1, 50, 2, 15.0, 100m },
                    { 3, 50, 1, 50, 1, 18.0, 100m },
                    { 4, 100, 2, 100, 1, 18.0, 100m },
                    { 5, 100, 2, 100, 2, 20.0, 100m },
                    { 6, 100, 2, 100, 1, 23.0, 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowTimes_CinemaId",
                table: "MovieShowTimes",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowTimes_MovieId",
                table: "MovieShowTimes",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieShowTimes");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
