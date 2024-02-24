using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Difficulties_DifficultyId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Exercises_ExercisesExerciseId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Types_TypesTypeId",
                table: "ExerciseTypes");

            migrationBuilder.RenameColumn(
                name: "TypesTypeId",
                table: "ExerciseTypes",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "ExercisesExerciseId",
                table: "ExerciseTypes",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTypes_TypesTypeId",
                table: "ExerciseTypes",
                newName: "IX_ExerciseTypes_TypeId");

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
                name: "FK_Exercises_Difficulties_DifficultyId",
                table: "Exercises",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "DifficultyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Exercises_ExerciseId",
                table: "ExerciseTypes",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Types_TypeId",
                table: "ExerciseTypes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Exercises_ExerciseId",
                table: "Types",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Difficulties_DifficultyId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Exercises_ExerciseId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Types_TypeId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Exercises_ExerciseId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_ExerciseId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Types");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "ExerciseTypes",
                newName: "TypesTypeId");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "ExerciseTypes",
                newName: "ExercisesExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTypes_TypeId",
                table: "ExerciseTypes",
                newName: "IX_ExerciseTypes_TypesTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Difficulties_DifficultyId",
                table: "Exercises",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "DifficultyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Exercises_ExercisesExerciseId",
                table: "ExerciseTypes",
                column: "ExercisesExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Types_TypesTypeId",
                table: "ExerciseTypes",
                column: "TypesTypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
