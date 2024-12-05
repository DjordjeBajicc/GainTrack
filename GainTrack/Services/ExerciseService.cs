using GainTrack.Data;
using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    class ExerciseService : IExerciseService
    {
        private GainTrackContext _context;

        public ExerciseService(GainTrackContext context)
        {
            _context = context;
        }
        public Task AddExerciseAsync(Exercise Exercise)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExerciserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exercise> GetExerciseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExerciseAsync(Exercise Exercise)
        {
            throw new NotImplementedException();
        }
    }
}
