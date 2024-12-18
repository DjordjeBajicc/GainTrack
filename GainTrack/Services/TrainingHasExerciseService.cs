using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GainTrack.Services
{
    public class TrainingHasExerciseService : ITrainingHasExerciseService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TrainingHasExerciseService(IServiceScopeFactory serviceScopeFactory)
        {
            _scopeFactory = serviceScopeFactory; 
        }
        public async Task AddTrainingHasExerciseAsync(int trainingId, int exerciseId, int numberOfSeries)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();

                // Proveri da li postoje Training i Exercise
                var training = await context.Trainings.FindAsync(trainingId);
                var exercise = await context.Exercises.FindAsync(exerciseId);

                if (training == null || exercise == null)
                {
                    throw new Exception("Training or Exercise not found.");
                }

                // Kreiraj novi TrainingHasExercise
                var trainingHasExercise = new TrainingHasExercise
                {
                    TrainingId = trainingId,
                    ExerciseId = exerciseId,
                    NumberOfSeries = numberOfSeries,
                    Deleted = 0
                };

                context.TrainingHasExercises.Add(trainingHasExercise);
                await context.SaveChangesAsync();
            }
        }


        public Task DeleteTrainingHasExerciseAsync(int TrainingId, int ExerciseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrainingHasExercise>> GetAllTrainingHasExercisesAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await context.TrainingHasExercises.ToListAsync();
            }
            
        }

        public Task<TrainingHasExercise> GetTrainingHasExerciseByIdAsync(int TrainingId, int ExerciseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrainingHasExercise>> GetTrainingHasExerciseByTrainingIdAsync(int TrainingId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await context.TrainingHasExercises.Include(t => t.Exercise).Where(t => t.TrainingId == TrainingId).ToListAsync();
            }
            
        }

        public Task UpdateTrainingHasExerciseAsync(TrainingHasExercise TrainingHasExercise)
        {
            throw new NotImplementedException();
        }
    }
}
