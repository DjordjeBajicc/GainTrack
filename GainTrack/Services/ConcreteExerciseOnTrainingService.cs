using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public class ConcreteExerciseOnTrainingService : IConcreteExerciseOnTrainingService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ConcreteExerciseOnTrainingService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task AddConcreteExerciseOnTrainingAsync(ConcreteExerciseOnTraining concreteExerciseOnTraining)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                await _context.ConcreteExercisesOnTraining.AddAsync(concreteExerciseOnTraining);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<ConcreteExerciseOnTraining>> GetAllConcreteExercisesOnTrainingsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ConcreteExerciseOnTraining> GetConcreteExerciseOnTrainingByTrainingHasExerciseIdAsync(int id)
        {
            using( var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.ConcreteExercisesOnTraining
                    .Include(e => e.TrainingHasExercise) 
                    .FirstOrDefaultAsync(e => e.TrainingHasExerciseId == id);
            }
        }

        public async Task<IEnumerable<ConcreteExerciseOnTraining>> GetConcreteExercisesOnTrainingsByTrainingHasExerciseIdAsync(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.ConcreteExercisesOnTraining
                                .Include(c => c.TrainingHasExercise)
                                .Where(c => c.TrainingHasExerciseId == id).ToListAsync();
            }
        }
    }
}
