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

    class TrainingService : ITraningService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TrainingService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task<Training> AddTrainingAsync(Training training)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                _context.Trainings.Add(training);
                await _context.SaveChangesAsync();
                return training;
            }
            
        }

        public async Task DeleteTrainingAsync(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();

                // Pronađi trening u bazi
                var training = await _context.Trainings.FindAsync(id);

                if (training != null)
                {
                    training.Deleted = 1;
                    _context.Trainings.Update(training);

                    // Sačuvaj promene u bazi
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Training with ID {id} not found.");
                }
            }
        }


        public Task<IEnumerable<Training>> GetAllTrainingsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Training> GetTrainingByIdAsync(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                var training = await _context.Trainings.FirstOrDefaultAsync(t => t.Id == id && t.Deleted == 0);

                if (training == null)
                {
                    throw new KeyNotFoundException($"Training with ID {id} not found.");
                }

                return training;
            }
               
        }

        public async Task<IEnumerable<Training>> GetTrainingsForUserAsync(int userId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Trainings
                                      .Where(t => t.UserId == userId && t.Deleted == 0)
                                      .ToListAsync();
            }
              
        }

        public async Task UpdateTrainingAsync(Training training)
        {
            if (training == null)
            {
                throw new ArgumentNullException(nameof(training));
            }

            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();

                _context.Trainings.Update(training);
                //_context.Entry(training).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

        }

    }
}
