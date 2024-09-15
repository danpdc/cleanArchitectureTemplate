using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physiqube.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class AddRunningActivity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "Running_DistanceId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Activities_Running_DistanceId",
            table: "Activities",
            column: "Running_DistanceId");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Distance_Running_DistanceId",
            table: "Activities",
            column: "Running_DistanceId",
            principalTable: "Distance",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Distance_Running_DistanceId",
            table: "Activities");

        migrationBuilder.DropIndex(
            name: "IX_Activities_Running_DistanceId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "Running_DistanceId",
            table: "Activities");
    }
}
