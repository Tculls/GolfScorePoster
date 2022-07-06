using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfScorePoster.Migrations
{
    public partial class GolfMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DatePlayed = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TeesPlayed = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoundScore = table.Column<int>(type: "int", nullable: false),
                    NineOrEighteen = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false),
                    PlayerUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_Scores_Users_PlayerUserId",
                        column: x => x.PlayerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoursePar = table.Column<int>(type: "int", nullable: false),
                    CourseRating = table.Column<int>(type: "int", nullable: false),
                    CourseSlope = table.Column<int>(type: "int", nullable: false),
                    PlayerUserId = table.Column<int>(type: "int", nullable: true),
                    PlayerScoreScoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Scores_PlayerScoreScoreId",
                        column: x => x.PlayerScoreScoreId,
                        principalTable: "Scores",
                        principalColumn: "ScoreId");
                    table.ForeignKey(
                        name: "FK_Courses_Users_PlayerUserId",
                        column: x => x.PlayerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    AssociationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.AssociationId);
                    table.ForeignKey(
                        name: "FK_Associations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Associations_Scores_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Scores",
                        principalColumn: "ScoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Associations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_CourseId",
                table: "Associations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_ScoreId",
                table: "Associations",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_UserId",
                table: "Associations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PlayerScoreScoreId",
                table: "Courses",
                column: "PlayerScoreScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PlayerUserId",
                table: "Courses",
                column: "PlayerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerUserId",
                table: "Scores",
                column: "PlayerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
