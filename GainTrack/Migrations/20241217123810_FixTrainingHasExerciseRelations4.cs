using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainTrack.Migrations
{
    /// <inheritdoc />
    public partial class FixTrainingHasExerciseRelations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteExercisesOnTraining_training_has_exercise_TrainingHa~",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteExercisesOnTraining_training_has_exercise_TrainingH~1",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_training_has_exercise_Exercise_ExerciseId1",
                table: "training_has_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_training_has_exercise_Training_TrainingId1",
                table: "training_has_exercise");

            migrationBuilder.DropForeignKey(
                name: "fk_Training_has_Exercise_Exercise1",
                table: "training_has_exercise");

            migrationBuilder.DropForeignKey(
                name: "fk_Training_has_Exercise_Training1",
                table: "training_has_exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_training_has_exercise",
                table: "training_has_exercise");

            migrationBuilder.RenameTable(
                name: "training_has_exercise",
                newName: "TrainingHasExercises");

            migrationBuilder.RenameIndex(
                name: "IX_training_has_exercise_TrainingId1",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_TrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_training_has_exercise_Training_Id",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_Training_Id");

            migrationBuilder.RenameIndex(
                name: "IX_training_has_exercise_ExerciseId1",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_ExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_training_has_exercise_Exercise_Id",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_Exercise_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingHasExercises",
                table: "TrainingHasExercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteExercisesOnTraining_TrainingHasExercises_TrainingHas~",
                table: "ConcreteExercisesOnTraining",
                column: "TrainingHasExerciseId",
                principalTable: "TrainingHasExercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteExercisesOnTraining_TrainingHasExercises_TrainingHa~1",
                table: "ConcreteExercisesOnTraining",
                column: "TrainingHasExerciseId1",
                principalTable: "TrainingHasExercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHasExercises_Exercise_ExerciseId1",
                table: "TrainingHasExercises",
                column: "ExerciseId1",
                principalTable: "Exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHasExercises_Exercise_Exercise_Id",
                table: "TrainingHasExercises",
                column: "Exercise_Id",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHasExercises_Training_TrainingId1",
                table: "TrainingHasExercises",
                column: "TrainingId1",
                principalTable: "Training",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHasExercises_Training_Training_Id",
                table: "TrainingHasExercises",
                column: "Training_Id",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteExercisesOnTraining_TrainingHasExercises_TrainingHas~",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteExercisesOnTraining_TrainingHasExercises_TrainingHa~1",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Exercise_ExerciseId1",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Exercise_Exercise_Id",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Training_TrainingId1",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Training_Training_Id",
                table: "TrainingHasExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingHasExercises",
                table: "TrainingHasExercises");

            migrationBuilder.RenameTable(
                name: "TrainingHasExercises",
                newName: "training_has_exercise");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_TrainingId1",
                table: "training_has_exercise",
                newName: "IX_training_has_exercise_TrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_Training_Id",
                table: "training_has_exercise",
                newName: "IX_training_has_exercise_Training_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_ExerciseId1",
                table: "training_has_exercise",
                newName: "IX_training_has_exercise_ExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_Exercise_Id",
                table: "training_has_exercise",
                newName: "IX_training_has_exercise_Exercise_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_training_has_exercise",
                table: "training_has_exercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteExercisesOnTraining_training_has_exercise_TrainingHa~",
                table: "ConcreteExercisesOnTraining",
                column: "TrainingHasExerciseId",
                principalTable: "training_has_exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteExercisesOnTraining_training_has_exercise_TrainingH~1",
                table: "ConcreteExercisesOnTraining",
                column: "TrainingHasExerciseId1",
                principalTable: "training_has_exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_training_has_exercise_Exercise_ExerciseId1",
                table: "training_has_exercise",
                column: "ExerciseId1",
                principalTable: "Exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_training_has_exercise_Training_TrainingId1",
                table: "training_has_exercise",
                column: "TrainingId1",
                principalTable: "Training",
                principalColumn: "Id");

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
    }
}
