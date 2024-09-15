using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physiqube.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class AddPaceToRunning : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "PaceId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "Pace",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Value = table.Column<TimeSpan>(type: "time", nullable: false),
                MeasurementSystem = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Pace", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Activities_PaceId",
            table: "Activities",
            column: "PaceId");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Pace_PaceId",
            table: "Activities",
            column: "PaceId",
            principalTable: "Pace",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Pace_PaceId",
            table: "Activities");

        migrationBuilder.DropTable(
            name: "Pace");

        migrationBuilder.DropIndex(
            name: "IX_Activities_PaceId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "PaceId",
            table: "Activities");
    }
}
