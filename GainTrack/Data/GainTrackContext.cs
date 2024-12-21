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

                modelBuilder.Entity<Exercise>().ToTable("Exercise");

            // Konfiguracija za tabelu Training
                modelBuilder.Entity<Training>()
                    .HasOne(t => t.User)
                    .WithMany(u => u.Training)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
                modelBuilder.Entity<Training>().ToTable("Training");

            // Konfiguracija za tabelu Training_has_Exercise
            modelBuilder.Entity<TrainingHasExercise>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.TrainingId)
                      .HasColumnName("Training_Id");

                entity.Property(e => e.ExerciseId)
                      .HasColumnName("Exercise_Id");

                entity.Property(e => e.NumberOfSeries)
                      .HasColumnName("Number_Of_Series");
                // Konfiguracija stranih ključeva
                entity.HasOne(e => e.Training)
                      .WithMany(t => t.TrainingHasExercises)
                      .HasForeignKey(e => e.TrainingId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Exercise)
                      .WithMany(t => t.TrainingHasExercises)
                      .HasForeignKey(e => e.ExerciseId)
                      .OnDelete(DeleteBehavior.Restrict);

                
            });
            modelBuilder.Entity<TrainingHasExercise>().ToTable("Training_has_Exercise");

            // Konfiguracija za tabelu Concrete_Exercise_On_Training
            modelBuilder.Entity<ConcreteExerciseOnTraining>(entity =>
            {
                entity.ToTable("Concrete_Exercise_On_Training");

                entity.HasKey(c => new { c.Date, c.TrainingHasExerciseId });

                entity.HasOne(c => c.TrainingHasExercise)
                      .WithMany(t => t.ConcreteExerciseOnTrainings) 
                      .HasForeignKey(c => c.TrainingHasExerciseId)
                      .OnDelete(DeleteBehavior.Restrict);
                      
            });

            modelBuilder.Entity<ConcreteExerciseOnTraining>().ToTable("Concrete_Exercise_on_Training");

            modelBuilder.Entity<Serie>(entity =>
            {
                // Postavi primarni ključ za Serie
                entity.HasKey(e => new { e.SerialNumber, e.ConcreteExerciseOnTrainingDate, e.ConcreteExerciseOnTrainingTrainingHasExerciseId });

                // Relacija između Serie i ConcreteExerciseOnTraining
                entity.HasOne(e => e.ConcreteExerciseOnTraining)
                    .WithMany(c => c.Series)
                    .HasForeignKey(e => new { e.ConcreteExerciseOnTrainingDate, e.ConcreteExerciseOnTrainingTrainingHasExerciseId })
                    .OnDelete(DeleteBehavior.Restrict);

                
            });
            
            // Konfiguracija za tabelu User_has_Messurement
            modelBuilder.Entity<UserHasMessurement>()
                    .HasKey(uhm => new { uhm.UserId, uhm.MessurementName, uhm.Date }); // Definisanje primarnog ključa

                modelBuilder.Entity<UserHasMessurement>()
                    .HasOne(uhm => uhm.User) // Navigacija prema User entitetu
                    .WithMany(u => u.UserHasMessurements) // Jedan User može imati više UserHasMessurements
                    .HasForeignKey(uhm => uhm.UserId) // Strani ključ za User
                    .OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<UserHasMessurement>()
                    .HasOne(uhm => uhm.Messurement) // Navigacija prema Messurement entitetu
                    .WithMany(m => m.UserHasMessurements) // Messurement ne mora imati kolekciju UserHasMessurements
                    .HasForeignKey(uhm => uhm.MessurementName) // Strani ključ za MessurementName
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserHasMessurement>().ToTable("User_Has_Messurement");
            // Konfiguracija za tabelu Weight_Exercise
            modelBuilder.Entity<WeightExercise>()
                    .HasKey(w => w.ExerciseId);
                modelBuilder.Entity<WeightExercise>()
                    .HasOne(w => w.Exercise)
                    .WithOne(e => e.WeightExercise)
                    .HasForeignKey<WeightExercise>(w => w.ExerciseId)
                    .OnDelete(DeleteBehavior.NoAction);
                modelBuilder.Entity<WeightExercise>().ToTable("Weight_Exercise");

            // Konfiguracija za tabelu Cardio_Exercise
                modelBuilder.Entity<CardioExercise>()
                    .HasKey(c => c.ExerciseId); // Ključ je ExerciseId

                modelBuilder.Entity<CardioExercise>()
                    .HasOne(c => c.Exercise)
                    .WithOne(e => e.CardioExercise)
                    .HasForeignKey<CardioExercise>(c => c.ExerciseId)
                    .OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<CardioExercise>().ToTable("Cardio_Exercise");
                    base.OnModelCreating(modelBuilder);
            }

        }
    }
