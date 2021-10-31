using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiCodingTest.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieListStatuses",
                columns: table => new
                {
                    Provider = table.Column<string>(type: "text", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieListStatuses", x => x.Provider);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProviderId = table.Column<string>(type: "text", nullable: true),
                    Provider = table.Column<string>(type: "text", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: true),
                    Rated = table.Column<string>(type: "text", nullable: true),
                    Released = table.Column<string>(type: "text", nullable: true),
                    Runtime = table.Column<string>(type: "text", nullable: true),
                    Genre = table.Column<string>(type: "text", nullable: true),
                    Director = table.Column<string>(type: "text", nullable: true),
                    Writer = table.Column<string>(type: "text", nullable: true),
                    Actors = table.Column<string>(type: "text", nullable: true),
                    Plot = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Poster = table.Column<string>(type: "text", nullable: true),
                    MetaScore = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<string>(type: "text", nullable: true),
                    Votes = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<string>(type: "text", nullable: true),
                    MovieId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieDetails_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_MovieId",
                table: "MovieDetails",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDetails");

            migrationBuilder.DropTable(
                name: "MovieListStatuses");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
