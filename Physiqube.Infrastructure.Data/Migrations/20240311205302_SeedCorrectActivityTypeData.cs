using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Physiqube.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class SeedCorrectActivityTypeData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "ActivityType",
            columns: new[] { "Id", "FriendlyName", "Type" },
            values: new object[,]
            {
                { 1, "Walking", "Walking" },
                { 2, "Cycling", "Cycling" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "ActivityType",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "ActivityType",
            keyColumn: "Id",
            keyValue: 2);
    }
}
