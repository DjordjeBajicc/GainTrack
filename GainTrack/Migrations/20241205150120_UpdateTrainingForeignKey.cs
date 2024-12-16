using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainTrack.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrainingForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Messurements",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Meassure = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messurements", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trainer = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_Trainer",
                        column: x => x.Trainer,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<sbyte>(type: "tinyint", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserHasMessurements",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MessurementName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MessurementName1 = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHasMessurements", x => new { x.UserId, x.MessurementName, x.Date });
                    table.ForeignKey(
                        name: "FK_UserHasMessurements_Messurements_MessurementName",
                        column: x => x.MessurementName,
                        principalTable: "Messurements",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_UserHasMessurements_Messurements_MessurementName1",
                        column: x => x.MessurementName1,
                        principalTable: "Messurements",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_UserHasMessurements_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CardioExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardioExercises", x => x.ExerciseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CardioSeries",
                columns: table => new
                {
                    SerieSerialNumber = table.Column<int>(type: "int", nullable: false),
                    SerieConcreteExerciseOnTrainingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SerieConcreteExerciseOnTrainingTrainingHasExerciseId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardioSeries", x => new { x.SerieSerialNumber, x.SerieConcreteExerciseOnTrainingDate, x.SerieConcreteExerciseOnTrainingTrainingHasExerciseId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConcreteExercisesOnTraining",
                columns: table => new
                {
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TrainingHasExerciseId = table.Column<int>(type: "int", nullable: false),
                    TrainingHasExerciseId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteExercisesOnTraining", x => new { x.Date, x.TrainingHasExerciseId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Deleted = table.Column<sbyte>(type: "tinyint", nullable: false),
                    CardioExerciseExerciseId = table.Column<int>(type: "int", nullable: true),
                    WeightExerciseExerciseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_CardioExercises_CardioExerciseExerciseId",
                        column: x => x.CardioExerciseExerciseId,
                        principalTable: "CardioExercises",
                        principalColumn: "ExerciseId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrainingHasExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeries = table.Column<int>(type: "int", nullable: false),
                    ExerciseId1 = table.Column<int>(type: "int", nullable: true),
                    TrainingId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingHasExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingHasExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingHasExercises_Exercises_ExerciseId1",
                        column: x => x.ExerciseId1,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingHasExercises_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingHasExercises_Training_TrainingId1",
                        column: x => x.TrainingId1,
                        principalTable: "Training",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeightExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightExercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_WeightExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    ConcreteExerciseOnTrainingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ConcreteExerciseOnTrainingTrainingHasExerciseId = table.Column<int>(type: "int", nullable: false),
                    CardioSerieSerieSerialNumber = table.Column<int>(type: "int", nullable: true),
                    CardioSerieSerieConcreteExerciseOnTrainingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CardioSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId = table.Column<int>(type: "int", nullable: true),
                    WeighSerieSerieSerialNumber = table.Column<int>(type: "int", nullable: true),
                    WeighSerieSerieConcreteExerciseOnTrainingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    WeighSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId = table.Column<int>(type: "int", nullable: true),
                    ConcreteExerciseOnTrainingDate1 = table.Column<DateOnly>(type: "date", nullable: true),
                    ConcreteExerciseOnTrainingTrainingHasExerciseId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => new { x.SerialNumber, x.ConcreteExerciseOnTrainingDate, x.ConcreteExerciseOnTrainingTrainingHasExerciseId });
                    table.ForeignKey(
                        name: "FK_Series_CardioSeries_CardioSerieSerieSerialNumber_CardioSerie~",
                        columns: x => new { x.CardioSerieSerieSerialNumber, x.CardioSerieSerieConcreteExerciseOnTrainingDate, x.CardioSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId },
                        principalTable: "CardioSeries",
                        principalColumns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" });
                    table.ForeignKey(
                        name: "FK_Series_ConcreteExercisesOnTraining_ConcreteExerciseOnTrainin~",
                        columns: x => new { x.ConcreteExerciseOnTrainingDate, x.ConcreteExerciseOnTrainingTrainingHasExerciseId },
                        principalTable: "ConcreteExercisesOnTraining",
                        principalColumns: new[] { "Date", "TrainingHasExerciseId" });
                    table.ForeignKey(
                        name: "FK_Series_ConcreteExercisesOnTraining_ConcreteExerciseOnTraini~1",
                        columns: x => new { x.ConcreteExerciseOnTrainingDate1, x.ConcreteExerciseOnTrainingTrainingHasExerciseId1 },
                        principalTable: "ConcreteExercisesOnTraining",
                        principalColumns: new[] { "Date", "TrainingHasExerciseId" });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeighSeries",
                columns: table => new
                {
                    SerieSerialNumber = table.Column<int>(type: "int", nullable: false),
                    SerieConcreteExerciseOnTrainingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SerieConcreteExerciseOnTrainingTrainingHasExerciseId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeighSeries", x => new { x.SerieSerialNumber, x.SerieConcreteExerciseOnTrainingDate, x.SerieConcreteExerciseOnTrainingTrainingHasExerciseId });
                    table.ForeignKey(
                        name: "FK_WeighSeries_Series_SerieSerialNumber_SerieConcreteExerciseOn~",
                        columns: x => new { x.SerieSerialNumber, x.SerieConcreteExerciseOnTrainingDate, x.SerieConcreteExerciseOnTrainingTrainingHasExerciseId },
                        principalTable: "Series",
                        principalColumns: new[] { "SerialNumber", "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId" });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteExercisesOnTraining_TrainingHasExerciseId",
                table: "ConcreteExercisesOnTraining",
                column: "TrainingHasExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteExercisesOnTraining_TrainingHasExerciseId1",
                table: "ConcreteExercisesOnTraining",
                column: "TrainingHasExerciseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CardioExerciseExerciseId",
                table: "Exercises",
                column: "CardioExerciseExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WeightExerciseExerciseId",
                table: "Exercises",
                column: "WeightExerciseExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_CardioSerieSerieSerialNumber_CardioSerieSerieConcrete~",
                table: "Series",
                columns: new[] { "CardioSerieSerieSerialNumber", "CardioSerieSerieConcreteExerciseOnTrainingDate", "CardioSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Series_ConcreteExerciseOnTrainingDate_ConcreteExerciseOnTrai~",
                table: "Series",
                columns: new[] { "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Series_ConcreteExerciseOnTrainingDate1_ConcreteExerciseOnTra~",
                table: "Series",
                columns: new[] { "ConcreteExerciseOnTrainingDate1", "ConcreteExerciseOnTrainingTrainingHasExerciseId1" });

            migrationBuilder.CreateIndex(
                name: "IX_Series_WeighSerieSerieSerialNumber_WeighSerieSerieConcreteEx~",
                table: "Series",
                columns: new[] { "WeighSerieSerieSerialNumber", "WeighSerieSerieConcreteExerciseOnTrainingDate", "WeighSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Training_User_Id",
                table: "Training",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Training_UserId1",
                table: "Training",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHasExercises_ExerciseId",
                table: "TrainingHasExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHasExercises_ExerciseId1",
                table: "TrainingHasExercises",
                column: "ExerciseId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHasExercises_TrainingId",
                table: "TrainingHasExercises",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHasExercises_TrainingId1",
                table: "TrainingHasExercises",
                column: "TrainingId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_Trainer",
                table: "User",
                column: "Trainer");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasMessurements_MessurementName",
                table: "UserHasMessurements",
                column: "MessurementName");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasMessurements_MessurementName1",
                table: "UserHasMessurements",
                column: "MessurementName1");

            migrationBuilder.AddForeignKey(
                name: "FK_CardioExercises_Exercises_ExerciseId",
                table: "CardioExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardioSeries_Series_SerieSerialNumber_SerieConcreteExerciseO~",
                table: "CardioSeries",
                columns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" },
                principalTable: "Series",
                principalColumns: new[] { "SerialNumber", "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId" });

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
                name: "FK_Exercises_WeightExercises_WeightExerciseExerciseId",
                table: "Exercises",
                column: "WeightExerciseExerciseId",
                principalTable: "WeightExercises",
                principalColumn: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_WeighSeries_WeighSerieSerieSerialNumber_WeighSerieSer~",
                table: "Series",
                columns: new[] { "WeighSerieSerieSerialNumber", "WeighSerieSerieConcreteExerciseOnTrainingDate", "WeighSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId" },
                principalTable: "WeighSeries",
                principalColumns: new[] { "SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardioExercises_Exercises_ExerciseId",
                table: "CardioExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Exercises_ExerciseId",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHasExercises_Exercises_ExerciseId1",
                table: "TrainingHasExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightExercises_Exercises_ExerciseId",
                table: "WeightExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_CardioSeries_Series_SerieSerialNumber_SerieConcreteExerciseO~",
                table: "CardioSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_WeighSeries_Series_SerieSerialNumber_SerieConcreteExerciseOn~",
                table: "WeighSeries");

            migrationBuilder.DropTable(
                name: "UserHasMessurements");

            migrationBuilder.DropTable(
                name: "Messurements");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "CardioExercises");

            migrationBuilder.DropTable(
                name: "WeightExercises");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "CardioSeries");

            migrationBuilder.DropTable(
                name: "ConcreteExercisesOnTraining");

            migrationBuilder.DropTable(
                name: "WeighSeries");

            migrationBuilder.DropTable(
                name: "TrainingHasExercises");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
