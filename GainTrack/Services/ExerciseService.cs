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
    class ExerciseService : IExerciseService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ExerciseService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task<Exercise> AddExerciseAsync(Exercise Exercise)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                await context.Exercises.AddAsync(Exercise);
                await context.SaveChangesAsync();

                return Exercise;
            }
        }

        public Task DeleteExerciserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await context.Exercises.ToListAsync();
            }
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await context.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            }
            
        }

        public Task UpdateExerciseAsync(Exercise Exercise)
        {
            throw new NotImplementedException();
        }
    }
}
