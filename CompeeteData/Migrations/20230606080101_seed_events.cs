using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompeeteData.Migrations
{
    /// <inheritdoc />
    public partial class seed_events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Adress", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { 1, "123 rue du test", "Un petit evenement bon pour les cochons", new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Local), "next1", new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "123 rue du test", "Un petit evenement bon pour les cochons", new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), "previous1", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "123 rue du test", "Un petit evenement bon pour les cochons", new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), "next2", new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "123 rue du test", "Un petit evenement bon pour les cochons", new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), "previous2", new DateTime(2023, 5, 26, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthdate",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
