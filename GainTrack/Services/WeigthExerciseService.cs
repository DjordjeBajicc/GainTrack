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
    public class WeigthExerciseService : IWeigthExerciseService
    {
        private GainTrackContext _context;

        public WeigthExerciseService(GainTrackContext context)
        {
            _context = context;
        }
        public async Task AddWeightExerciseAsync(WeightExercise weightExercise)
        {
            _context.WeightExercises.Add(weightExercise);
            await _context.SaveChangesAsync();
        }

        public Task DeleteWeightExerciseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WeightExercise>> GetAllWeightExercisesAsync()
        {
            return await _context.WeightExercises.ToListAsync();
        }

        public Task<Training> GetWeightExerciseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
