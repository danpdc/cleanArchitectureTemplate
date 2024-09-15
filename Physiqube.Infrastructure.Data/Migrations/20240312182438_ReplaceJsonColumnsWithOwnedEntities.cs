using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physiqube.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class ReplaceJsonColumnsWithOwnedEntities : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "AverageSpeed",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "ElevationGain",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "ElevationLoss",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "MaxSpeed",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "TripDistance",
            table: "Activities");

        migrationBuilder.DropColumn(
            name: "WalkedDistance",
            table: "Activities");

        migrationBuilder.RenameColumn(
            name: "Weight",
            table: "Athletes",
            newName: "ProfileSettings_PreferredTimezone");

        migrationBuilder.RenameColumn(
            name: "ProfileSettings",
            table: "Athletes",
            newName: "Location_Region");

        migrationBuilder.RenameColumn(
            name: "Location",
            table: "Athletes",
            newName: "Location_Country");

        migrationBuilder.RenameColumn(
            name: "Height",
            table: "Athletes",
            newName: "Location_City");

        migrationBuilder.AddColumn<int>(
            name: "ProfileSettings_PreferredMeasurementSystem",
            table: "Athletes",
            type: "int",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ProfileSettings_PreferredMeasurementSystem",
            table: "Athletes");

        migrationBuilder.RenameColumn(
            name: "ProfileSettings_PreferredTimezone",
            table: "Athletes",
            newName: "Weight");

        migrationBuilder.RenameColumn(
            name: "Location_Region",
            table: "Athletes",
            newName: "ProfileSettings");

        migrationBuilder.RenameColumn(
            name: "Location_Country",
            table: "Athletes",
            newName: "Location");

        migrationBuilder.RenameColumn(
            name: "Location_City",
            table: "Athletes",
            newName: "Height");

        migrationBuilder.AddColumn<string>(
            name: "AverageSpeed",
            table: "Activities",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ElevationGain",
            table: "Activities",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ElevationLoss",
            table: "Activities",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "MaxSpeed",
            table: "Activities",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "TripDistance",
            table: "Activities",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "WalkedDistance",
            table: "Activities",
            type: "nvarchar(max)",
            nullable: true);
    }
}
