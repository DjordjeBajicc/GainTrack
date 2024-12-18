using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainTrack.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "IX_Training_has_Exercise_ExerciseId1",
                table: "Training_has_Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Training_has_Exercise_TrainingId1",
                table: "Training_has_Exercise");

            migrationBuilder.DropColumn(
                name: "ExerciseId1",
                table: "Training_has_Exercise");

            migrationBuilder.DropColumn(
                name: "TrainingId1",
                table: "Training_has_Exercise");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_has_Exercise_Exercise_Exercise_Id",
                table: "Training_has_Exercise",
                column: "Exercise_Id",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_has_Exercise_Training_Training_Id",
                table: "Training_has_Exercise",
                column: "Training_Id",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_has_Exercise_Exercise_Exercise_Id",
                table: "Training_has_Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_has_Exercise_Training_Training_Id",
                table: "Training_has_Exercise");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId1",
                table: "Training_has_Exercise",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingId1",
                table: "Training_has_Exercise",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Training_has_Exercise_ExerciseId1",
                table: "Training_has_Exercise",
                column: "ExerciseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Training_has_Exercise_TrainingId1",
                table: "Training_has_Exercise",
                column: "TrainingId1");

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
        }
    }
}
