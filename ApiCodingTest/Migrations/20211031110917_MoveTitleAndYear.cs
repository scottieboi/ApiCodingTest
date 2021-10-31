using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCodingTest.Migrations
{
    public partial class MoveTitleAndYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "MovieDetails");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MovieDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "MovieDetails",
                type: "text",
                nullable: true);
        }
    }
}
