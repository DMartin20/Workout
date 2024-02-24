using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Types_Exercises_ExerciseId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_ExerciseId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Types");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Types",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_ExerciseId",
                table: "Types",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Exercises_ExerciseId",
                table: "Types",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId");
        }
    }
}
