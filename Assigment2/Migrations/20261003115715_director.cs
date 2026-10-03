using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assigment2.Migrations
{
    /// <inheritdoc />
    public partial class director : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Direction",
                table: "Movies",
                newName: "Director");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Director",
                table: "Movies",
                newName: "Direction");
        }
    }
}
