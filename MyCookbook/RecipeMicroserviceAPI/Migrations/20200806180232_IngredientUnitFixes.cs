using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeMicroserviceAPI.Migrations
{
    public partial class IngredientUnitFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_UnitId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Ingredients");

            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "RecipeIngredient",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_UnitId",
                table: "RecipeIngredient",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Units_UnitId",
                table: "RecipeIngredient",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Units_UnitId",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_UnitId",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "RecipeIngredient");

            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "Ingredients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_UnitId",
                table: "Ingredients",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                table: "Ingredients",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
