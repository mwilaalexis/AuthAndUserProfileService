using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserProfileServiceProject.Migrations
{
    /// <inheritdoc />
    public partial class SecondMIgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "Goal",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ActivityLevel",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Allergies",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BiologicalSex",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HeightCm",
                table: "Profiles",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Profiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightKg",
                table: "Profiles",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Allergies",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "BiologicalSex",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HeightCm",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "WeightKg",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "Goal",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Profiles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Profiles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
