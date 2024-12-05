    using GainTrack.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace GainTrack.Data
    {
        public class GainTrackContext : DbContext
        {
            public GainTrackContext(DbContextOptions<GainTrackContext> options) : base(options) { }

            // DbSets for tables
            public DbSet<User> Users { get; set; }
            public DbSet<Training> Trainings { get; set; }
            public DbSet<Exercise> Exercises { get; set; }
            public DbSet<TrainingHasExercise> TrainingHasExercises { get; set; }
            public DbSet<ConcreteExerciseOnTraining> ConcreteExercisesOnTraining { get; set; }
            public DbSet<Serie> Series { get; set; }
            public DbSet<WeighSerie> WeighSeries { get; set; }
            public DbSet<CardioSerie> CardioSeries { get; set; }
            public DbSet<Messurement> Messurements { get; set; }
            public DbSet<UserHasMessurement> UserHasMessurements { get; set; }
            public DbSet<WeightExercise> WeightExercises { get; set; }
            public DbSet<CardioExercise> CardioExercises { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Konfiguracija za tabelu User
                modelBuilder.Entity<User>()
                    .HasOne(u => u.TrainerNavigation) // Navigacija prema trenerskom korisniku
                    .WithMany(u => u.InverseTrainerNavigation) // Trener može imati više korisnika
                    .HasForeignKey(u => u.Trainer) // Strani ključ
                    .OnDelete(DeleteBehavior.NoAction);
                modelBuilder.Entity<User>().ToTable("User");

            // Konfiguracija za tabelu Training
            modelBuilder.Entity<Training>()
                    .HasOne(t => t.User)
                    .WithMany()
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Konfiguracija za tabelu Training_has_Exercise
                modelBuilder.Entity<TrainingHasExercise>()
                    .HasKey(t => t.Id);
                modelBuilder.Entity<TrainingHasExercise>()
                    .HasOne(t => t.Training)
                    .WithMany()
                    .HasForeignKey(t => t.TrainingId)
                    .OnDelete(DeleteBehavior.NoAction);
                modelBuilder.Entity<TrainingHasExercise>()
                    .HasOne(t => t.Exercise)
                    .WithMany()
                    .HasForeignKey(t => t.ExerciseId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Konfiguracija za tabelu Concrete_Exercise_On_Training
                modelBuilder.Entity<ConcreteExerciseOnTraining>()
                    .HasKey(c => new { c.Date, c.TrainingHasExerciseId });
                modelBuilder.Entity<ConcreteExerciseOnTraining>()
                    .HasOne(c => c.TrainingHasExercise)
                    .WithMany()
                    .HasForeignKey(c => c.TrainingHasExerciseId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Konfiguracija za tabelu Serie
                modelBuilder.Entity<Serie>()
                    .HasKey(s => new { s.SerialNumber, s.ConcreteExerciseOnTrainingDate, s.ConcreteExerciseOnTrainingTrainingHasExerciseId });
                modelBuilder.Entity<Serie>()
                    .HasOne(s => s.ConcreteExerciseOnTraining)
                    .WithMany()
                    .HasForeignKey(s => new { s.ConcreteExerciseOnTrainingDate, s.ConcreteExerciseOnTrainingTrainingHasExerciseId })
                    .OnDelete(DeleteBehavior.NoAction);

                // Konfiguracija za tabelu Weigh_Serie
                modelBuilder.Entity<WeighSerie>()
                    .HasKey(w => new { w.SerieSerialNumber, w.SerieConcreteExerciseOnTrainingDate, w.SerieConcreteExerciseOnTrainingTrainingHasExerciseId });
                modelBuilder.Entity<WeighSerie>()
                    .HasOne(w => w.Serie)
                    .WithMany()
                    .HasForeignKey(w => new { w.SerieSerialNumber, w.SerieConcreteExerciseOnTrainingDate, w.SerieConcreteExerciseOnTrainingTrainingHasExerciseId })
                    .OnDelete(DeleteBehavior.NoAction);

                // Konfiguracija za tabelu Cardio_Serie
                modelBuilder.Entity<CardioSerie>()
                    .HasKey(c => new { c.SerieSerialNumber, c.SerieConcreteExerciseOnTrainingDate, c.SerieConcreteExerciseOnTrainingTrainingHasExerciseId });
                modelBuilder.Entity<CardioSerie>()
                    .HasOne(c => c.Serie)
                    .WithMany()
                    .HasForeignKey(c => new { c.SerieSerialNumber, c.SerieConcreteExerciseOnTrainingDate, c.SerieConcreteExerciseOnTrainingTrainingHasExerciseId })
                    .OnDelete(DeleteBehavior.NoAction);

                // Konfiguracija za tabelu User_has_Messurement
                modelBuilder.Entity<UserHasMessurement>()
            .HasKey(uhm => new { uhm.UserId, uhm.MessurementName, uhm.Date }); // Definisanje primarnog ključa

                modelBuilder.Entity<UserHasMessurement>()
                    .HasOne(uhm => uhm.User) // Navigacija prema User entitetu
                    .WithMany(u => u.UserHasMessurements) // Jedan User može imati više UserHasMessurements
                    .HasForeignKey(uhm => uhm.UserId) // Strani ključ za User
                    .OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<UserHasMessurement>()
                    .HasOne(uhm => uhm.MessurementNameNavigation) // Navigacija prema Messurement entitetu
                    .WithMany() // Messurement ne mora imati kolekciju UserHasMessurements
                    .HasForeignKey(uhm => uhm.MessurementName) // Strani ključ za MessurementName
                    .OnDelete(DeleteBehavior.NoAction);
                // Konfiguracija za tabelu Weight_Exercise
                modelBuilder.Entity<WeightExercise>()
                    .HasKey(w => w.ExerciseId);
                modelBuilder.Entity<WeightExercise>()
                    .HasOne(w => w.Exercise)
                    .WithOne()
                    .HasForeignKey<WeightExercise>(w => w.ExerciseId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Konfiguracija za tabelu Cardio_Exercise
                modelBuilder.Entity<CardioExercise>()
                    .HasKey(c => c.ExerciseId);
                modelBuilder.Entity<CardioExercise>()
                    .HasOne(c => c.Exercise)
                    .WithOne()
                    .HasForeignKey<CardioExercise>(c => c.ExerciseId)
                    .OnDelete(DeleteBehavior.NoAction);

                base.OnModelCreating(modelBuilder);
            }

        }
    }
