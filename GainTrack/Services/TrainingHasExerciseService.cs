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
    public class TrainingHasExerciseService : ITrainingHasExerciseService
    {
        private GainTrackContext _context;

        public TrainingHasExerciseService(GainTrackContext context)
        {
            _context = context; 
        }
        public Task AddTrainignHasExerciseAsync(TrainingHasExercise TrainingHasExercise)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTrainingHasExerciseAsync(int TrainingId, int ExerciseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrainingHasExercise>> GetAllTrainingHasExercisesAsync()
        {
            return await _context.TrainingHasExercises.ToListAsync();
        }

        public Task<TrainingHasExercise> GetTrainingHasExerciseByIdAsync(int TrainingId, int ExerciseId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTrainingHasExerciseAsync(TrainingHasExercise TrainingHasExercise)
        {
            throw new NotImplementedException();
        }
    }
}
