using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Physiqube.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class ChangeDBStructure : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Activities_ActivityType_ActivityTypeId",
            table: "Activities");

        migrationBuilder.DropTable(
            name: "ActivityType");

        migrationBuilder.DropIndex(
            name: "IX_Activities_ActivityTypeId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "Location_City",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "Location_Country",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "Location_Region",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "ProfileSettings_PreferredMeasurementSystem",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "ProfileSettings_PreferredTimezone",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "ActivityTypeId",
            table: "Activities");

        migrationBuilder.AddColumn<Guid>(
            name: "HeightId",
            table: "Athletes",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "LocationId",
            table: "Athletes",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "ProfileSettingsId",
            table: "Athletes",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "WeightId",
            table: "Athletes",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "AverageSpeedId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "DistanceId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "ElevationGainId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "ElevationLossId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "MaxSpeedId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "TripDistanceId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "Walking_DistanceId",
            table: "Activities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "Distance",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Value = table.Column<double>(type: "float", nullable: false),
                MeasurementSystem = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Distance", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Height",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Value = table.Column<double>(type: "float", nullable: false),
                MeasurementSystem = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Height", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Location",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                City = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Location", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ProfileSettings",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PreferredMeasurementSystem = table.Column<int>(type: "int", nullable: false),
                PreferredTimezone = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProfileSettings", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Speed",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Value = table.Column<double>(type: "float", nullable: false),
                MeasurementSystem = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Speed", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Weight",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Value = table.Column<double>(type: "float", nullable: false),
                MeasurementSystem = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Weight", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Athletes_HeightId",
            table: "Athletes",
            column: "HeightId");

        migrationBuilder.CreateIndex(
            name: "IX_Athletes_LocationId",
            table: "Athletes",
            column: "LocationId");

        migrationBuilder.CreateIndex(
            name: "IX_Athletes_ProfileSettingsId",
            table: "Athletes",
            column: "ProfileSettingsId");

        migrationBuilder.CreateIndex(
            name: "IX_Athletes_WeightId",
            table: "Athletes",
            column: "WeightId");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_AverageSpeedId",
            table: "Activities",
            column: "AverageSpeedId");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_DistanceId",
            table: "Activities",
            column: "DistanceId");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_ElevationGainId",
            table: "Activities",
            column: "ElevationGainId");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_ElevationLossId",
            table: "Activities",
            column: "ElevationLossId");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_MaxSpeedId",
            table: "Activities",
            column: "MaxSpeedId");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_TripDistanceId",
            table: "Activities",
            column: "TripDistanceId");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_Walking_DistanceId",
            table: "Activities",
            column: "Walking_DistanceId");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Distance_DistanceId",
            table: "Activities",
            column: "DistanceId",
            principalTable: "Distance",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Distance_TripDistanceId",
            table: "Activities",
            column: "TripDistanceId",
            principalTable: "Distance",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Distance_Walking_DistanceId",
            table: "Activities",
            column: "Walking_DistanceId",
            principalTable: "Distance",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Height_ElevationGainId",
            table: "Activities",
            column: "ElevationGainId",
            principalTable: "Height",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Height_ElevationLossId",
            table: "Activities",
            column: "ElevationLossId",
            principalTable: "Height",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Speed_AverageSpeedId",
            table: "Activities",
            column: "AverageSpeedId",
            principalTable: "Speed",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_Speed_MaxSpeedId",
            table: "Activities",
            column: "MaxSpeedId",
            principalTable: "Speed",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Athletes_Height_HeightId",
            table: "Athletes",
            column: "HeightId",
            principalTable: "Height",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Athletes_Location_LocationId",
            table: "Athletes",
            column: "LocationId",
            principalTable: "Location",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Athletes_ProfileSettings_ProfileSettingsId",
            table: "Athletes",
            column: "ProfileSettingsId",
            principalTable: "ProfileSettings",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Athletes_Weight_WeightId",
            table: "Athletes",
            column: "WeightId",
            principalTable: "Weight",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Distance_DistanceId",
            table: "Activities");

        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Distance_TripDistanceId",
            table: "Activities");

        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Distance_Walking_DistanceId",
            table: "Activities");

        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Height_ElevationGainId",
            table: "Activities");

        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Height_ElevationLossId",
            table: "Activities");

        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Speed_AverageSpeedId",
            table: "Activities");

        migrationBuilder.DropForeignKey(
            name: "FK_Activities_Speed_MaxSpeedId",
            table: "Activities");

        migrationBuilder.DropForeignKey(
            name: "FK_Athletes_Height_HeightId",
            table: "Athletes");

        migrationBuilder.DropForeignKey(
            name: "FK_Athletes_Location_LocationId",
            table: "Athletes");

        migrationBuilder.DropForeignKey(
            name: "FK_Athletes_ProfileSettings_ProfileSettingsId",
            table: "Athletes");

        migrationBuilder.DropForeignKey(
            name: "FK_Athletes_Weight_WeightId",
            table: "Athletes");

        migrationBuilder.DropTable(
            name: "Distance");

        migrationBuilder.DropTable(
            name: "Height");

        migrationBuilder.DropTable(
            name: "Location");

        migrationBuilder.DropTable(
            name: "ProfileSettings");

        migrationBuilder.DropTable(
            name: "Speed");

        migrationBuilder.DropTable(
            name: "Weight");

        migrationBuilder.DropIndex(
            name: "IX_Athletes_HeightId",
            table: "Athletes");

        migrationBuilder.DropIndex(
            name: "IX_Athletes_LocationId",
            table: "Athletes");

        migrationBuilder.DropIndex(
            name: "IX_Athletes_ProfileSettingsId",
            table: "Athletes");

        migrationBuilder.DropIndex(
            name: "IX_Athletes_WeightId",
            table: "Athletes");

        migrationBuilder.DropIndex(
            name: "IX_Activities_AverageSpeedId",
            table: "Activities");

        migrationBuilder.DropIndex(
            name: "IX_Activities_DistanceId",
            table: "Activities");

        migrationBuilder.DropIndex(
            name: "IX_Activities_ElevationGainId",
            table: "Activities");

        migrationBuilder.DropIndex(
            name: "IX_Activities_ElevationLossId",
            table: "Activities");

        migrationBuilder.DropIndex(
            name: "IX_Activities_MaxSpeedId",
            table: "Activities");

        migrationBuilder.DropIndex(
            name: "IX_Activities_TripDistanceId",
            table: "Activities");

        migrationBuilder.DropIndex(
            name: "IX_Activities_Walking_DistanceId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "HeightId",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "LocationId",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "ProfileSettingsId",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "WeightId",
            table: "Athletes");

        migrationBuilder.DropColumn(
            name: "AverageSpeedId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "DistanceId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "ElevationGainId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "ElevationLossId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "MaxSpeedId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "TripDistanceId",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "Walking_DistanceId",
            table: "Activities");

        migrationBuilder.AddColumn<string>(
            name: "Location_City",
            table: "Athletes",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Location_Country",
            table: "Athletes",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Location_Region",
            table: "Athletes",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "ProfileSettings_PreferredMeasurementSystem",
            table: "Athletes",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ProfileSettings_PreferredTimezone",
            table: "Athletes",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "ActivityTypeId",
            table: "Activities",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateTable(
            name: "ActivityType",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ActivityType", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "ActivityType",
            columns: new[] { "Id", "FriendlyName", "Type" },
            values: new object[,]
            {
                { 1, "Walking", "Walking" },
                { 2, "Cycling", "Cycling" }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Activities_ActivityTypeId",
            table: "Activities",
            column: "ActivityTypeId");

        migrationBuilder.AddForeignKey(
            name: "FK_Activities_ActivityType_ActivityTypeId",
            table: "Activities",
            column: "ActivityTypeId",
            principalTable: "ActivityType",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
