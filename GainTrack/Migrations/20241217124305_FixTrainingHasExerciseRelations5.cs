using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainTrack.Migrations
{
    /// <inheritdoc />
    public partial class FixTrainingHasExerciseRelations5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteExercisesOnTraining_TrainingHasExercises_TrainingHas~",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteExercisesOnTraining_TrainingHasExercises_TrainingHa~1",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_ConcreteExercisesOnTraining_ConcreteExerciseOnTrainin~",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_ConcreteExercisesOnTraining_ConcreteExerciseOnTraini~1",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_WeighSeries_WeighSerieSerieSerialNumber_WeighSerieSer~",
                table: "Series");

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

            migrationBuilder.DropForeignKey(
                name: "FK_WeighSeries_Series_SerieSerialNumber_SerieConcreteExerciseOn~",
                table: "WeighSeries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeighSeries",
                table: "WeighSeries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingHasExercises",
                table: "TrainingHasExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConcreteExercisesOnTraining",
                table: "ConcreteExercisesOnTraining");

            migrationBuilder.RenameTable(
                name: "WeighSeries",
                newName: "User_Has_Messurement");

            migrationBuilder.RenameTable(
                name: "TrainingHasExercises",
                newName: "Training_has_Exercise");

            migrationBuilder.RenameTable(
                name: "ConcreteExercisesOnTraining",
                newName: "Concrete_Exercise_on_Training");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_TrainingId1",
                table: "Training_has_Exercise",
                newName: "IX_Training_has_Exercise_TrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_Training_Id",
                table: "Training_has_Exercise",
                newName: "IX_Training_has_Exercise_Training_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_ExerciseId1",
                table: "Training_has_Exercise",
                newName: "IX_Training_has_Exercise_ExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHasExercises_Exercise_Id",
                table: "Training_has_Exercise",
                newName: "IX_Training_has_Exercise_Exercise_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ConcreteExercisesOnTraining_TrainingHasExerciseId1",
                table: "Concrete_Exercise_on_Training",
                newName: "IX_Concrete_Exercise_on_Training_TrainingHasExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_ConcreteExercisesOnTraining_TrainingHasExerciseId",
                table: "Concrete_Exercise_on_Training",
                newName: "IX_Concrete_Exercise_on_Training_TrainingHasExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Has_Messurement",
                table: "User_Has_Messurement",
                columns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training_has_Exercise",
                table: "Training_has_Exercise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concrete_Exercise_on_Training",
                table: "Concrete_Exercise_on_Training",
                columns: new[] { "Date", "TrainingHasExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Concrete_Exercise_on_Training_Training_has_Exercise_Training~",
                table: "Concrete_Exercise_on_Training",
                column: "TrainingHasExerciseId",
                principalTable: "Training_has_Exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concrete_Exercise_on_Training_Training_has_Exercise_Trainin~1",
                table: "Concrete_Exercise_on_Training",
                column: "TrainingHasExerciseId1",
                principalTable: "Training_has_Exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Concrete_Exercise_on_Training_ConcreteExerciseOnTrain~",
                table: "Series",
                columns: new[] { "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId" },
                principalTable: "Concrete_Exercise_on_Training",
                principalColumns: new[] { "Date", "TrainingHasExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Concrete_Exercise_on_Training_ConcreteExerciseOnTrai~1",
                table: "Series",
                columns: new[] { "ConcreteExerciseOnTrainingDate1", "ConcreteExerciseOnTrainingTrainingHasExerciseId1" },
                principalTable: "Concrete_Exercise_on_Training",
                principalColumns: new[] { "Date", "TrainingHasExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Series_User_Has_Messurement_WeighSerieSerieSerialNumber_Weig~",
                table: "Series",
                columns: new[] { "WeighSerieSerieSerialNumber", "WeighSerieSerieConcreteExerciseOnTrainingDate", "WeighSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId" },
                principalTable: "User_Has_Messurement",
                principalColumns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Training_has_Exercise_Exercise_ExerciseId1",
                table: "Training_has_Exercise",
                column: "ExerciseId1",
                principalTable: "Exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_has_Exercise_Exercise_Exercise_Id",
                table: "Training_has_Exercise",
                column: "Exercise_Id",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_has_Exercise_Training_TrainingId1",
                table: "Training_has_Exercise",
                column: "TrainingId1",
                principalTable: "Training",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_has_Exercise_Training_Training_Id",
                table: "Training_has_Exercise",
                column: "Training_Id",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Has_Messurement_Series_SerieSerialNumber_SerieConcreteE~",
                table: "User_Has_Messurement",
                columns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" },
                principalTable: "Series",
                principalColumns: new[] { "SerialNumber", "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concrete_Exercise_on_Training_Training_has_Exercise_Training~",
                table: "Concrete_Exercise_on_Training");

            migrationBuilder.DropForeignKey(
                name: "FK_Concrete_Exercise_on_Training_Training_has_Exercise_Trainin~1",
                table: "Concrete_Exercise_on_Training");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Concrete_Exercise_on_Training_ConcreteExerciseOnTrain~",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Concrete_Exercise_on_Training_ConcreteExerciseOnTrai~1",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_User_Has_Messurement_WeighSerieSerieSerialNumber_Weig~",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_has_Exercise_Exercise_ExerciseId1",
                table: "Training_has_Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_has_Exercise_Exercise_Exercise_Id",
                table: "Training_has_Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_has_Exercise_Training_TrainingId1",
                table: "Training_has_Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_has_Exercise_Training_Training_Id",
                table: "Training_has_Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Has_Messurement_Series_SerieSerialNumber_SerieConcreteE~",
                table: "User_Has_Messurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Has_Messurement",
                table: "User_Has_Messurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training_has_Exercise",
                table: "Training_has_Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concrete_Exercise_on_Training",
                table: "Concrete_Exercise_on_Training");

            migrationBuilder.RenameTable(
                name: "User_Has_Messurement",
                newName: "WeighSeries");

            migrationBuilder.RenameTable(
                name: "Training_has_Exercise",
                newName: "TrainingHasExercises");

            migrationBuilder.RenameTable(
                name: "Concrete_Exercise_on_Training",
                newName: "ConcreteExercisesOnTraining");

            migrationBuilder.RenameIndex(
                name: "IX_Training_has_Exercise_TrainingId1",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_TrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_Training_has_Exercise_Training_Id",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_Training_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Training_has_Exercise_ExerciseId1",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_ExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_Training_has_Exercise_Exercise_Id",
                table: "TrainingHasExercises",
                newName: "IX_TrainingHasExercises_Exercise_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Concrete_Exercise_on_Training_TrainingHasExerciseId1",
                table: "ConcreteExercisesOnTraining",
                newName: "IX_ConcreteExercisesOnTraining_TrainingHasExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_Concrete_Exercise_on_Training_TrainingHasExerciseId",
                table: "ConcreteExercisesOnTraining",
                newName: "IX_ConcreteExercisesOnTraining_TrainingHasExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeighSeries",
                table: "WeighSeries",
                columns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingHasExercises",
                table: "TrainingHasExercises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConcreteExercisesOnTraining",
                table: "ConcreteExercisesOnTraining",
                columns: new[] { "Date", "TrainingHasExerciseId" });

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
                name: "FK_Series_ConcreteExercisesOnTraining_ConcreteExerciseOnTrainin~",
                table: "Series",
                columns: new[] { "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId" },
                principalTable: "ConcreteExercisesOnTraining",
                principalColumns: new[] { "Date", "TrainingHasExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Series_ConcreteExercisesOnTraining_ConcreteExerciseOnTraini~1",
                table: "Series",
                columns: new[] { "ConcreteExerciseOnTrainingDate1", "ConcreteExerciseOnTrainingTrainingHasExerciseId1" },
                principalTable: "ConcreteExercisesOnTraining",
                principalColumns: new[] { "Date", "TrainingHasExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Series_WeighSeries_WeighSerieSerieSerialNumber_WeighSerieSer~",
                table: "Series",
                columns: new[] { "WeighSerieSerieSerialNumber", "WeighSerieSerieConcreteExerciseOnTrainingDate", "WeighSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId" },
                principalTable: "WeighSeries",
                principalColumns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_WeighSeries_Series_SerieSerialNumber_SerieConcreteExerciseOn~",
                table: "WeighSeries",
                columns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" },
                principalTable: "Series",
                principalColumns: new[] { "SerialNumber", "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId" });
        }
    }
}
