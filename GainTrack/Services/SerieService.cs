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
                return await _context.Series.Where(s => s.ConcreteExerciseOnTrainingDate.Equals(date) && s.ConcreteExerciseOnTrainingTrainingHasExerciseId == id).ToListAsync();
            }
        }

        public Task<Serie> GetSerieByConcreteExerciseOnTrainingTrainingHasExerciseIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
