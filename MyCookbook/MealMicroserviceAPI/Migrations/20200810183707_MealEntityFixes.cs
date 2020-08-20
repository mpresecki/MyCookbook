using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealMicroserviceAPI.Migrations
{
    public partial class MealEntityFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Meals");

            migrationBuilder.AddColumn<DateTime>(
                name: "MealDay",
                table: "Meals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealDay",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
