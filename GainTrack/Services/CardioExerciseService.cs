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
    public class CardioExerciseService : ICardioExerciseService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CardioExerciseService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task AddCardioExerciseAsync(CardioExercise CardioExercise)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                await context.CardioExercises.AddAsync(CardioExercise);
                await context.SaveChangesAsync();
            }
            
            
        }

        public Task DeleteCardioExerciseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CardioExercise>> GetAllCardioExercisesAsync()
        {
            using( var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await context.CardioExercises.ToListAsync();
            }
            
        }

        public Task<Training> GetCardioExerciseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
