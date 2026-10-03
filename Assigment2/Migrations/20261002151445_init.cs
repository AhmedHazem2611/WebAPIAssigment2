using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assigment2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed@gmail.com", "Ahmed Ali", "01012345678" },
                    { 2, "omar@gmail.com", "Omar Hassan", "01112345678" },
                    { 3, "mohamed@gmail.com", "Mohamed Samir", "01212345678" },
                    { 4, "youssef@gmail.com", "Youssef Ibrahim", "01512345678" },
                    { 5, "karim@gmail.com", "Karim Mahmoud", "01098765432" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Horror" },
                    { 5, "Science Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AvailableSeats", "Direction", "Duration", "GenreId", "Rating", "ReleaseYear", "TicketPrice", "Title" },
                values: new object[,]
                {
                    { 1, 50, "Christopher Nolan", 148, 5, 9, 2010, 150m, "Inception" },
                    { 2, 45, "Christopher Nolan", 152, 1, 9, 2008, 180m, "The Dark Knight" },
                    { 3, 60, "Todd Phillips", 100, 2, 8, 2009, 120m, "The Hangover" },
                    { 4, 40, "Frank Darabont", 142, 3, 10, 1994, 140m, "The Shawshank Redemption" },
                    { 5, 55, "Christopher Nolan", 169, 5, 9, 2014, 170m, "Interstellar" },
                    { 6, 35, "Andy Muschietti", 135, 4, 7, 2017, 130m, "It" },
                    { 7, 50, "Robert Zemeckis", 142, 3, 9, 1994, 130m, "Forrest Gump" },
                    { 8, 45, "Ridley Scott", 155, 1, 9, 2000, 160m, "Gladiator" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CustomerId", "MovieId", "NumberOfTickets", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, 300 },
                    { 2, new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 3, 540 },
                    { 3, new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 2, 240 },
                    { 4, new DateTime(2026, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, 1, 170 },
                    { 5, new DateTime(2026, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 6, 4, 520 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MovieId",
                table: "Bookings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Title",
                table: "Movies",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
