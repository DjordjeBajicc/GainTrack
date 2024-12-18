﻿// <auto-generated />
using System;
using GainTrack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GainTrack.Migrations
{
    [DbContext(typeof(GainTrackContext))]
    [Migration("20241216150201_FixTrainingHasExerciseRelations2")]
    partial class FixTrainingHasExerciseRelations2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GainTrack.Data.Entities.CardioExercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("Exercise_Id");

                    b.HasKey("ExerciseId");

                    b.ToTable("Cardio_Exercise", (string)null);
                });

            modelBuilder.Entity("GainTrack.Data.Entities.CardioSerie", b =>
                {
                    b.Property<int>("SerieSerialNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly>("SerieConcreteExerciseOnTrainingDate")
                        .HasColumnType("date");

                    b.Property<int>("SerieConcreteExerciseOnTrainingTrainingHasExerciseId")
                        .HasColumnType("int");

                    b.Property<TimeOnly?>("Time")
                        .HasColumnType("time(6)");

                    b.HasKey("SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId");

                    b.ToTable("CardioSeries");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.ConcreteExerciseOnTraining", b =>
                {
                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("TrainingHasExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingHasExerciseId1")
                        .HasColumnType("int");

                    b.HasKey("Date", "TrainingHasExerciseId");

                    b.HasIndex("TrainingHasExerciseId");

                    b.HasIndex("TrainingHasExerciseId1");

                    b.ToTable("ConcreteExercisesOnTraining");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<sbyte>("Deleted")
                        .HasColumnType("tinyint");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Exercise", (string)null);
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Messurement", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Meassure")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Name");

                    b.ToTable("Messurements");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Serie", b =>
                {
                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ConcreteExerciseOnTrainingDate")
                        .HasColumnType("date");

                    b.Property<int>("ConcreteExerciseOnTrainingTrainingHasExerciseId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("CardioSerieSerieConcreteExerciseOnTrainingDate")
                        .HasColumnType("date");

                    b.Property<int?>("CardioSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("CardioSerieSerieSerialNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ConcreteExerciseOnTrainingDate1")
                        .HasColumnType("date");

                    b.Property<int?>("ConcreteExerciseOnTrainingTrainingHasExerciseId1")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("WeighSerieSerieConcreteExerciseOnTrainingDate")
                        .HasColumnType("date");

                    b.Property<int?>("WeighSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("WeighSerieSerieSerialNumber")
                        .HasColumnType("int");

                    b.HasKey("SerialNumber", "ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId");

                    b.HasIndex("ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId");

                    b.HasIndex("ConcreteExerciseOnTrainingDate1", "ConcreteExerciseOnTrainingTrainingHasExerciseId1");

                    b.HasIndex("CardioSerieSerieSerialNumber", "CardioSerieSerieConcreteExerciseOnTrainingDate", "CardioSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId");

                    b.HasIndex("WeighSerieSerieSerialNumber", "WeighSerieSerieConcreteExerciseOnTrainingDate", "WeighSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<sbyte>("Deleted")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Training", (string)null);
                });

            modelBuilder.Entity("GainTrack.Data.Entities.TrainingHasExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<sbyte>("Deleted")
                        .HasColumnType("tinyint");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("Exercise_Id");

                    b.Property<int?>("ExerciseId1")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeries")
                        .HasColumnType("int")
                        .HasColumnName("Number_Of_Series");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int")
                        .HasColumnName("Training_Id");

                    b.Property<int?>("TrainingId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("ExerciseId1");

                    b.HasIndex("TrainingId");

                    b.HasIndex("TrainingId1");

                    b.ToTable("training_has_exercise", (string)null);
                });

            modelBuilder.Entity("GainTrack.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<sbyte>("Deleted")
                        .HasColumnType("tinyint");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Trainer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Trainer");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("GainTrack.Data.Entities.UserHasMessurement", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("MessurementName")
                        .HasColumnType("varchar(255)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("MessurementName1")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "MessurementName", "Date");

                    b.HasIndex("MessurementName");

                    b.HasIndex("MessurementName1");

                    b.ToTable("UserHasMessurements");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.WeighSerie", b =>
                {
                    b.Property<int>("SerieSerialNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly>("SerieConcreteExerciseOnTrainingDate")
                        .HasColumnType("date");

                    b.Property<int>("SerieConcreteExerciseOnTrainingTrainingHasExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId");

                    b.ToTable("WeighSeries");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.WeightExercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("Exercise_Id");

                    b.HasKey("ExerciseId");

                    b.ToTable("Weight_Exercise", (string)null);
                });

            modelBuilder.Entity("GainTrack.Data.Entities.CardioExercise", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.Exercise", "Exercise")
                        .WithOne("CardioExercise")
                        .HasForeignKey("GainTrack.Data.Entities.CardioExercise", "ExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.CardioSerie", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.ConcreteExerciseOnTraining", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.TrainingHasExercise", "TrainingHasExercise")
                        .WithMany()
                        .HasForeignKey("TrainingHasExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GainTrack.Data.Entities.TrainingHasExercise", null)
                        .WithMany("ConcreteExerciseOnTrainings")
                        .HasForeignKey("TrainingHasExerciseId1")
                        .HasConstraintName("FK_ConcreteExercisesOnTraining_training_has_exercise_TrainingH~1");

                    b.Navigation("TrainingHasExercise");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Serie", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.ConcreteExerciseOnTraining", "ConcreteExerciseOnTraining")
                        .WithMany()
                        .HasForeignKey("ConcreteExerciseOnTrainingDate", "ConcreteExerciseOnTrainingTrainingHasExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GainTrack.Data.Entities.ConcreteExerciseOnTraining", null)
                        .WithMany("Series")
                        .HasForeignKey("ConcreteExerciseOnTrainingDate1", "ConcreteExerciseOnTrainingTrainingHasExerciseId1")
                        .HasConstraintName("FK_Series_ConcreteExercisesOnTraining_ConcreteExerciseOnTraini~1");

                    b.HasOne("GainTrack.Data.Entities.CardioSerie", "CardioSerie")
                        .WithMany()
                        .HasForeignKey("CardioSerieSerieSerialNumber", "CardioSerieSerieConcreteExerciseOnTrainingDate", "CardioSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId");

                    b.HasOne("GainTrack.Data.Entities.WeighSerie", "WeighSerie")
                        .WithMany()
                        .HasForeignKey("WeighSerieSerieSerialNumber", "WeighSerieSerieConcreteExerciseOnTrainingDate", "WeighSerieSerieConcreteExerciseOnTrainingTrainingHasExerciseId");

                    b.Navigation("CardioSerie");

                    b.Navigation("ConcreteExerciseOnTraining");

                    b.Navigation("WeighSerie");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Training", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.User", "User")
                        .WithMany("Training")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.TrainingHasExercise", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_Training_has_Exercise_Exercise1");

                    b.HasOne("GainTrack.Data.Entities.Exercise", null)
                        .WithMany("TrainingHasExercises")
                        .HasForeignKey("ExerciseId1");

                    b.HasOne("GainTrack.Data.Entities.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_Training_has_Exercise_Training1");

                    b.HasOne("GainTrack.Data.Entities.Training", null)
                        .WithMany("TrainingHasExercises")
                        .HasForeignKey("TrainingId1");

                    b.Navigation("Exercise");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.User", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.User", "TrainerNavigation")
                        .WithMany("InverseTrainerNavigation")
                        .HasForeignKey("Trainer")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("TrainerNavigation");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.UserHasMessurement", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.Messurement", "MessurementNameNavigation")
                        .WithMany()
                        .HasForeignKey("MessurementName")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GainTrack.Data.Entities.Messurement", null)
                        .WithMany("UserHasMessurements")
                        .HasForeignKey("MessurementName1");

                    b.HasOne("GainTrack.Data.Entities.User", "User")
                        .WithMany("UserHasMessurements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MessurementNameNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.WeighSerie", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieSerialNumber", "SerieConcreteExerciseOnTrainingDate", "SerieConcreteExerciseOnTrainingTrainingHasExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.WeightExercise", b =>
                {
                    b.HasOne("GainTrack.Data.Entities.Exercise", "Exercise")
                        .WithOne("WeightExercise")
                        .HasForeignKey("GainTrack.Data.Entities.WeightExercise", "ExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.ConcreteExerciseOnTraining", b =>
                {
                    b.Navigation("Series");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Exercise", b =>
                {
                    b.Navigation("CardioExercise");

                    b.Navigation("TrainingHasExercises");

                    b.Navigation("WeightExercise");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Messurement", b =>
                {
                    b.Navigation("UserHasMessurements");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.Training", b =>
                {
                    b.Navigation("TrainingHasExercises");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.TrainingHasExercise", b =>
                {
                    b.Navigation("ConcreteExerciseOnTrainings");
                });

            modelBuilder.Entity("GainTrack.Data.Entities.User", b =>
                {
                    b.Navigation("InverseTrainerNavigation");

                    b.Navigation("Training");

                    b.Navigation("UserHasMessurements");
                });
#pragma warning restore 612, 618
        }
    }
}
