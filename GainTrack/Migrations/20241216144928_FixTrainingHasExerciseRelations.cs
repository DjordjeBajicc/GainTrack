using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainTrack.Migrations
{
    /// <inheritdoc />
    public partial class FixTrainingHasExerciseRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardioExercises_Exercises_ExerciseId",
                table: "CardioExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteExercisesOnTraining_TrainingHasExercises_TrainingHas~",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteExercisesOnTraining_TrainingHasExercises_TrainingHa~1",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_CardioExercises_CardioExerciseExerciseId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_WeightExercises_WeightExerciseExerciseId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_User_UserId1",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Exercises_ExerciseId",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Exercises_ExerciseId1",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Training_TrainingId",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Training_TrainingId1",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightExercises_Exercises_ExerciseId",
                table: "WeightExercises");

            migrationBuilder.DropIndex(
                name: "IX_Training_UserId1",
                table: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeightExercises",
                table: "WeightExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingHasExercises",
                table: "TrainingHasExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CardioExerciseExerciseId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_WeightExerciseExerciseId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardioExercises",
                table: "CardioExercises");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "CardioExerciseExerciseId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "WeightExerciseExerciseId",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "WeightExercises",
                newName: "Weight_Exercise");

            migrationBuilder.RenameTable(
                name: "TrainingHasExercises",
                newName: "training_has_exercise");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameTable(
                name: "CardioExercises",
                newName: "Cardio_Exercise");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "Weight_Exercise",
                newName: "Exercise_Id");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "training_has_exercise",
                newName: "Training_Id");

            migrationBuilder.RenameColumn(
                name: "NumberOfSeries",
                table: "training_has_exercise",
                newName: "Number_Of_Series");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "training_has_exercise",
                newName: "Exercise_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_TrainingId1",
                table: "training_has_exercise",
                newName: "IX_training_has_exercise_TrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_TrainingId",
                table: "training_has_exercise",
                newName: "IX_training_has_exercise_Training_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_ExerciseId1",
                table: "training_has_exercise",
                newName: "IX_training_has_exercise_ExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_ExerciseId",
                table: "training_has_exercise",
                newName: "IX_training_has_exercise_Exercise_Id");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "Cardio_Exercise",
                newName: "Exercise_Id");

            migrationBuilder.AddColumn<sbyte>(
                name: "Deleted",
                table: "training_has_exercise",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weight_Exercise",
                table: "Weight_Exercise",
                column: "Exercise_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_training_has_exercise",
                table: "training_has_exercise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cardio_Exercise",
                table: "Cardio_Exercise",
                column: "Exercise_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cardio_Exercise_Exercise_Exercise_Id",
                table: "Cardio_Exercise",
                column: "Exercise_Id",
                principalTable: "Exercise",
                principalColumn: "Id");

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
                name: "FK_training_has_exercise_Exercise_Exercise_Id",
                table: "training_has_exercise",
                column: "Exercise_Id",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_training_has_exercise_Training_TrainingId1",
                table: "training_has_exercise",
                column: "TrainingId1",
                principalTable: "Training",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_training_has_exercise_Training_Training_Id",
                table: "training_has_exercise",
                column: "Training_Id",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weight_Exercise_Exercise_Exercise_Id",
                table: "Weight_Exercise",
                column: "Exercise_Id",
                principalTable: "Exercise",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cardio_Exercise_Exercise_Exercise_Id",
                table: "Cardio_Exercise");

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
                name: "FK_training_has_exercise_Exercise_Exercise_Id",
                table: "training_has_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_training_has_exercise_Training_TrainingId1",
                table: "training_has_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_training_has_exercise_Training_Training_Id",
                table: "training_has_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Weight_Exercise_Exercise_Exercise_Id",
                table: "Weight_Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weight_Exercise",
                table: "Weight_Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_training_has_exercise",
                table: "training_has_exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cardio_Exercise",
                table: "Cardio_Exercise");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "training_has_exercise");

            migrationBuilder.RenameTable(
                name: "Weight_Exercise",
                newName: "WeightExercises");

            migrationBuilder.RenameTable(
                name: "training_has_exercise",
                newName: "TrainingHasExercises");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameTable(
                name: "Cardio_Exercise",
                newName: "CardioExercises");

            migrationBuilder.RenameColumn(
                name: "Exercise_Id",
                table: "WeightExercises",
                newName: "ExerciseId");

            migrationBuilder.RenameColumn(
                name: "Training_Id",
                table: "TrainingHasExercises",
                newName: "TrainingId");

            migrationBuilder.RenameColumn(
                name: "Number_Of_Series",
                table: "TrainingHasExercises",
                newName: "NumberOfSeries");

            migrationBuilder.RenameColumn(
                name: "Exercise_Id",
                table: "TrainingHasExercises",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_training_has_exercise_TrainingId1",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_TrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_training_has_exercise_Training_Id",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_training_has_exercise_ExerciseId1",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_ExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_training_has_exercise_Exercise_Id",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_ExerciseId");

            migrationBuilder.RenameColumn(
                name: "Exercise_Id",
                table: "CardioExercises",
                newName: "ExerciseId");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Training",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardioExerciseExerciseId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeightExerciseExerciseId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeightExercises",
                table: "WeightExercises",
                column: "ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingHasExercises",
                table: "TrainingHasExercises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardioExercises",
                table: "CardioExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_UserId1",
                table: "Training",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CardioExerciseExerciseId",
                table: "Exercises",
                column: "CardioExerciseExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WeightExerciseExerciseId",
                table: "Exercises",
                column: "WeightExerciseExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardioExercises_Exercises_ExerciseId",
                table: "CardioExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

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
                name: "FK_Exercises_CardioExercises_CardioExerciseExerciseId",
                table: "Exercises",
                column: "CardioExerciseExerciseId",
                principalTable: "CardioExercises",
                principalColumn: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_WeightExercises_WeightExerciseExerciseId",
                table: "Exercises",
                column: "WeightExerciseExerciseId",
                principalTable: "WeightExercises",
                principalColumn: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_User_UserId1",
                table: "Training",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHasExercises_Exercises_ExerciseId",
                table: "TrainingHasExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHasExercises_Exercises_ExerciseId1",
                table: "TrainingHasExercises",
                column: "ExerciseId1",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHasExercises_Training_TrainingId",
                table: "TrainingHasExercises",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHasExercises_Training_TrainingId1",
                table: "TrainingHasExercises",
                column: "TrainingId1",
                principalTable: "Training",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeightExercises_Exercises_ExerciseId",
                table: "WeightExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
