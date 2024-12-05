using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{

    class TrainingService : ITraningService
    {
        private GainTrackContext _context;

        public TrainingService(GainTrackContext context)
        {
            _context = context; 
        }
        public Task AddTrainingAsync(Training training)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTrainingAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Training>> GetAllTrainingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Training> GetTrainingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Training>> GetTrainingsForUserAsync(int userId)
        {
            return await _context.Trainings
                .Where(t => t.Id == userId)
                .ToListAsync();
        }

        public Task UpdateTrainingAsync(Training training)
        {
            throw new NotImplementedException();
        }
    }
}
