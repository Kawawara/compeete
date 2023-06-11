using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompeeteData.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConstraintId",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNumber",
                table: "Constraints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TournamentUser",
                columns: table => new
                {
                    TournamentsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentUser", x => new { x.TournamentsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TournamentUser_Tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Boxe" },
                    { 2, "Judo" },
                    { 3, "Lutte" },
                    { 4, "Natation" },
                    { 5, "Badminton" },
                    { 6, "Plongeon" },
                    { 7, "Tennis" },
                    { 8, "Tennis de Table" },
                    { 9, "Cyclisme" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_ConstraintId",
                table: "Tournaments",
                column: "ConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_EventId",
                table: "Tournaments",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_SportId",
                table: "Tournaments",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_TournamentId",
                table: "Results",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentUser_UsersId",
                table: "TournamentUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Tournaments_TournamentId",
                table: "Results",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Constraints_ConstraintId",
                table: "Tournaments",
                column: "ConstraintId",
                principalTable: "Constraints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Events_EventId",
                table: "Tournaments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Sports_SportId",
                table: "Tournaments",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Tournaments_TournamentId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Constraints_ConstraintId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Events_EventId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Sports_SportId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "TournamentUser");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_ConstraintId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_EventId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_SportId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Results_TournamentId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_UserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "ConstraintId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "MaxNumber",
                table: "Constraints");
        }
    }
}
