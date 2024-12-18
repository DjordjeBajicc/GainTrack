using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainTrack.Migrations
{
    /// <inheritdoc />
    public partial class FixTrainingHasExerciseRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_training_has_exercise_Exercise_Exercise_Id",
                table: "training_has_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_training_has_exercise_Training_Training_Id",
                table: "training_has_exercise");

            migrationBuilder.AddForeignKey(
                name: "fk_Training_has_Exercise_Exercise1",
                table: "training_has_exercise",
                column: "Exercise_Id",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_Training_has_Exercise_Training1",
                table: "training_has_exercise",
                column: "Training_Id",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Training_has_Exercise_Exercise1",
                table: "training_has_exercise");

            migrationBuilder.DropForeignKey(
                name: "fk_Training_has_Exercise_Training1",
                table: "training_has_exercise");

            migrationBuilder.AddForeignKey(
                name: "FK_training_has_exercise_Exercise_Exercise_Id",
                table: "training_has_exercise",
                column: "Exercise_Id",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_training_has_exercise_Training_Training_Id",
                table: "training_has_exercise",
                column: "Training_Id",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
