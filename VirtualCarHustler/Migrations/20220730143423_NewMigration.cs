using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualCarHustler.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadLine",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Vehicles");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadLine",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
