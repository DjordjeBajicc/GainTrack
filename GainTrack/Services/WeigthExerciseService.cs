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
    public class WeigthExerciseService : IWeigthExerciseService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public WeigthExerciseService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task AddWeightExerciseAsync(WeightExercise weightExercise)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                await context.WeightExercises.AddAsync(weightExercise);
                await context.SaveChangesAsync();
            }
            
        }

        public Task DeleteWeightExerciseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WeightExercise>> GetAllWeightExercisesAsync()
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await context.WeightExercises.ToListAsync();
            }
            
        }

        public Task<Training> GetWeightExerciseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
