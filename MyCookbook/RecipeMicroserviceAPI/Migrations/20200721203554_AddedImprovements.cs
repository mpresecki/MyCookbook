using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeMicroserviceAPI.Migrations
{
    public partial class AddedImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnitAbbreviation",
                table: "Units",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitAbbreviation",
                table: "Units");
        }
    }
}
