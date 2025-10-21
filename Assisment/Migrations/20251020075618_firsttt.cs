using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assisment.Migrations
{
    /// <inheritdoc />
    public partial class firsttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experience_years = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coachID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teams_coaches_coachID",
                        column: x => x.coachID,
                        principalTable: "coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionTeam",
                columns: table => new
                {
                    competitionsId = table.Column<int>(type: "int", nullable: false),
                    teamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTeam", x => new { x.competitionsId, x.teamsId });
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_competitions_competitionsId",
                        column: x => x.competitionsId,
                        principalTable: "competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_teams_teamsId",
                        column: x => x.teamsId,
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    teamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_players_teams_teamID",
                        column: x => x.teamID,
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "coaches",
                columns: new[] { "Id", "Name", "Specialization", "experience_years" },
                values: new object[,]
                {
                    { 1, "Flick", "Football", 15 },
                    { 2, "Maresca", "HandBall", 5 },
                    { 3, "Ibrahim", "VoleyBall", 3 },
                    { 4, "Ibrahim", "VoleyBall", 3 }
                });

            migrationBuilder.InsertData(
                table: "competitions",
                columns: new[] { "Id", "Date", "Location", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), "America", "World-Cup" },
                    { 2, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), "Morroco", "Africa-Cup" },
                    { 3, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), "Qtar", "Arab-Cup" },
                    { 4, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), "France", "Europe-Cup" }
                });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "Id", "Name", "city", "coachID" },
                values: new object[,]
                {
                    { 1, "Al-Ahly", "Egypt", 4 },
                    { 2, "Barca", "Spain", 3 },
                    { 3, "Liverpool", "England", 2 },
                    { 4, "Inter", "Italy", 1 }
                });

            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "Id", "Full_name", "age", "position", "teamID" },
                values: new object[,]
                {
                    { 1, "Seif_Hamdy", 18, "CAM", 2 },
                    { 2, "Afsha", 30, "CM", 1 },
                    { 3, "Lamyen", 18, "RW", 3 },
                    { 4, "Vivi", 25, "LW", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTeam_teamsId",
                table: "CompetitionTeam",
                column: "teamsId");

            migrationBuilder.CreateIndex(
                name: "IX_players_teamID",
                table: "players",
                column: "teamID");

            migrationBuilder.CreateIndex(
                name: "IX_teams_coachID",
                table: "teams",
                column: "coachID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teams_Name",
                table: "teams",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionTeam");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "competitions");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "coaches");
        }
    }
}
