using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Addrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Types_TypeId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TypeId",
                table: "Exercises");

            migrationBuilder.CreateTable(
                name: "ExerciseTypes",
                columns: table => new
                {
                    ExercisesExerciseId = table.Column<int>(type: "int", nullable: false),
                    TypesTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => new { x.ExercisesExerciseId, x.TypesTypeId });
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Exercises_ExercisesExerciseId",
                        column: x => x.ExercisesExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Types_TypesTypeId",
                        column: x => x.TypesTypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_TypesTypeId",
                table: "ExerciseTypes",
                column: "TypesTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TypeId",
                table: "Exercises",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Types_TypeId",
                table: "Exercises",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
