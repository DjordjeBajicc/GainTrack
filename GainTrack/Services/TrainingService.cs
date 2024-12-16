using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
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
        private GainTrackContext _context;

        public TrainingService(GainTrackContext context)
        {
            _context = context; 
        }
        public async Task<Training> AddTrainingAsync(Training training)
        {
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();
            return training;
        }

        public async Task DeleteTrainingAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Training>> GetAllTrainingsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Training> GetTrainingByIdAsync(int id)
        {
            var training = await _context.Trainings.FirstOrDefaultAsync(t => t.Id == id);

            if (training == null)
            {
                throw new KeyNotFoundException($"Training with ID {id} not found.");
            }

            return training;
        }

        public async Task<IEnumerable<Training>> GetTrainingsForUserAsync(int userId)
        {
            //MessageBox.Show("sdafd");
            return await _context.Trainings
                .Where(t => t.UserId == userId && t.Deleted == 0)
                .ToListAsync();
        }

        public async Task UpdateTrainingAsync(Training training)
        {
            if (training == null)
            {
                throw new ArgumentNullException(nameof(training));
            }

            _context.Trainings.Update(training);
            //_context.Entry(training).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
