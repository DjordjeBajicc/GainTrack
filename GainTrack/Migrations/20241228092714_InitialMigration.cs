﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Deleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Messurements",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    Firstname = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Theme = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Language = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Deleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cardio_Exercise",
                columns: table => new
                {
                    Exercise_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardio_Exercise", x => x.Exercise_Id);
                    table.ForeignKey(
                        name: "FK_Cardio_Exercise_Exercise_Exercise_Id",
                        column: x => x.Exercise_Id,
                        principalTable: "Exercise",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Weight_Exercise",
                columns: table => new
                {
                    Exercise_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weight_Exercise", x => x.Exercise_Id);
                    table.ForeignKey(
                        name: "FK_Weight_Exercise_Exercise_Exercise_Id",
                        column: x => x.Exercise_Id,
                        principalTable: "Exercise",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Trainer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Trainee_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Trainee_User_UserId",
                        column: x => x.UserId,
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
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trainee_Id = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Trainee_Trainee_Id",
                        column: x => x.Trainee_Id,
                        principalTable: "Trainee",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User_Has_Messurement",
                columns: table => new
                {
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    MessurementName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Has_Messurement", x => new { x.TraineeId, x.MessurementName, x.Date });
                    table.ForeignKey(
                        name: "FK_User_Has_Messurement_Messurements_MessurementName",
                        column: x => x.MessurementName,
                        principalTable: "Messurements",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_User_Has_Messurement_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Training_has_Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Training_Id = table.Column<int>(type: "int", nullable: false),
                    Exercise_Id = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Number_Of_Series = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_has_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_has_Exercise_Exercise_Exercise_Id",
                        column: x => x.Exercise_Id,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Training_has_Exercise_Training_Training_Id",
                        column: x => x.Training_Id,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Concrete_Exercise_on_Training",
                columns: table => new
                {
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TrainingHasExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concrete_Exercise_on_Training", x => new { x.Date, x.TrainingHasExerciseId });
                    table.ForeignKey(
                        name: "FK_Concrete_Exercise_on_Training_Training_has_Exercise_Training~",
                        column: x => x.TrainingHasExerciseId,
                        principalTable: "Training_has_Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    ConcreteExerciseOnTrainingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ConcreteExerciseOnTrainingTrainingHasExerciseId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<TimeOnly>(type: "time(6)", nullable: true),
                    Distance = table.Column<decimal>(type: "decimal(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => new { x.SerialNumber, x.ConcreteExerciseOnTrainingDate, x.ConcreteExerciseOnTrainingTrainingHasExerciseId });
                    table.ForeignKey(
                        name: "FK_Series_Concrete_Exercise_on_Training_ConcreteExerciseOnTrain~",
                        columns: x => new { x.ConcreteExerciseOnTrainingDate, x.ConcreteExerciseOnTrainingTrainingHasExerciseId },
                        principalTable: "Concrete_Exercise_on_Training",
                        principalColumns: new[] { "Date", "TrainingHasExerciseId" },
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Concrete_Exercise_on_Training_TrainingHasExerciseId",
                table: "Concrete_Exercise_on_Training",
                column: "TrainingHasExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ConcreteExerciseOnTrainingDate_ConcreteExerciseOnTrai~",
                table: "Series",
                columns: new[] { "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_TrainerId",
                table: "Trainee",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_Trainee_Id",
                table: "Training",
                column: "Trainee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Training_has_Exercise_Exercise_Id",
                table: "Training_has_Exercise",
                column: "Exercise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Training_has_Exercise_Training_Id",
                table: "Training_has_Exercise",
                column: "Training_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Has_Messurement_MessurementName",
                table: "User_Has_Messurement",
                column: "MessurementName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cardio_Exercise");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "User_Has_Messurement");

            migrationBuilder.DropTable(
                name: "Weight_Exercise");

            migrationBuilder.DropTable(
                name: "Concrete_Exercise_on_Training");

            migrationBuilder.DropTable(
                name: "Messurements");

            migrationBuilder.DropTable(
                name: "Training_has_Exercise");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
