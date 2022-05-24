using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TVShowTracker.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasOscar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorShow",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "int", nullable: false),
                    ShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorShow", x => new { x.ActorsId, x.ShowsId });
                    table.ForeignKey(
                        name: "FK_ActorShow_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorShow_Shows_ShowsId",
                        column: x => x.ShowsId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Age", "HasOscar", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, 42, false, "Travis Fimmel", "Australian" },
                    { 2, 44, false, "Katheryn Winnick", "Canadian" },
                    { 3, 64, false, "Giancarlo Esposito", "American" },
                    { 4, 66, false, "Bryan Cranston", "American" },
                    { 5, 55, false, "Kiefer Sutherland", "English" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "ShowId" },
                values: new object[,]
                {
                    { 6, "Action", null },
                    { 5, "Documentary", null },
                    { 4, "Science fiction", null },
                    { 2, "Comedy", null },
                    { 1, "Drama", null },
                    { 3, "Horror", null }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "24: Redemption" },
                    { 1, "Vikings" },
                    { 2, "Raised by Wolves" },
                    { 3, "Breaking Bad" },
                    { 4, "Better Call Saul" },
                    { 6, "Designated Survivor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorShow_ShowsId",
                table: "ActorShow",
                column: "ShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_ShowId",
                table: "Episodes",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ShowId",
                table: "Genres",
                column: "ShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorShow");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
