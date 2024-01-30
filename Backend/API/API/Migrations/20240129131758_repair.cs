using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class repair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Difficulties_DifficultyId1",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Types_TypeId1",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_DifficultyId1",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TypeId1",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "DifficultyId1",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TypeId1",
                table: "Exercises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DifficultyId1",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId1",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_DifficultyId1",
                table: "Exercises",
                column: "DifficultyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TypeId1",
                table: "Exercises",
                column: "TypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Difficulties_DifficultyId1",
                table: "Exercises",
                column: "DifficultyId1",
                principalTable: "Difficulties",
                principalColumn: "DifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Types_TypeId1",
                table: "Exercises",
                column: "TypeId1",
                principalTable: "Types",
                principalColumn: "TypeId");
        }
    }
}
