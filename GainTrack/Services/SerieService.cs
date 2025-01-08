using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GainTrack.Services
{
    public class SerieService : ISerieService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public SerieService(IServiceScopeFactory serviceScopeFactory)
        {
            _scopeFactory = serviceScopeFactory;
        }
        public async Task AddSerieAsync(Serie serie)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                
                var existingEntity = _context.Series
                        .FirstOrDefault(s => s.SerialNumber == serie.SerialNumber &&
                         s.ConcreteExerciseOnTrainingDate == serie.ConcreteExerciseOnTrainingDate &&
                         s.ConcreteExerciseOnTrainingTrainingHasExerciseId == serie.ConcreteExerciseOnTrainingTrainingHasExerciseId);

                if (existingEntity == null)
                {
                    await _context.Series.AddAsync(serie);
                    await _context.SaveChangesAsync();// Dodaj novi entitet ako ne postoji
                }
            }
        }

        public Task<IEnumerable<Serie>> GetAllSeriesOnTrainingsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Serie>> GetSerieByConcreteExerciseOnTrainingTrainingHasExerciseIdAndDateAsync(int id, DateOnly date)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                var series = await _context.Series.Include(s => s.ConcreteExerciseOnTraining)
                                  .ThenInclude(cot => cot.TrainingHasExercise)
                                  .ThenInclude(the => the.Exercise)
                                  .Where(s => s.ConcreteExerciseOnTrainingDate.Equals(date)
                                              && s.ConcreteExerciseOnTraining.TrainingHasExercise.Training.Id == id)
                                  .ToListAsync();

                //foreach (var serie in series)
                //{
                //    MessageBox.Show($"Serie: {serie.SerialNumber}, Exercise Name: {serie.ConcreteExerciseOnTraining.TrainingHasExercise.Exercise.Name}");
                //}

                return series;
            }
        }

        public Task<Serie> GetSerieByConcreteExerciseOnTrainingTrainingHasExerciseIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Serie>> GetSeriesByTraineeAndExerciseAsync(int traineeId, int exerciseId)
        {
            using( var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Series
                    .Include(s => s.ConcreteExerciseOnTraining)
                        .ThenInclude(ce => ce.TrainingHasExercise)
                            .ThenInclude(eot => eot.Exercise)
                    .Include(s => s.ConcreteExerciseOnTraining)
                        .ThenInclude(ce => ce.TrainingHasExercise)
                            .ThenInclude(eot => eot.Training)
                    .Where(s =>
                        s.ConcreteExerciseOnTraining.TrainingHasExercise.Exercise.Id == exerciseId &&
                        s.ConcreteExerciseOnTraining.TrainingHasExercise.Training.TraineeId == traineeId)
                    .ToListAsync();
            }
        }
    }
}
