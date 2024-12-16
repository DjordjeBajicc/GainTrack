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
    public class TrainingHasExerciseService : ITrainingHasExerciseService
    {
        private GainTrackContext _context;

        public TrainingHasExerciseService(GainTrackContext context)
        {
            _context = context; 
        }
        public async Task AddTrainignHasExerciseAsync(TrainingHasExercise TrainingHasExercise)
        {
            await _context.TrainingHasExercises.AddAsync(TrainingHasExercise);
            await _context.SaveChangesAsync();
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

        public async Task<IEnumerable<TrainingHasExercise>> GetTrainingHasExerciseByTrainingIdAsync(int TrainingId)
        {
           return await _context.TrainingHasExercises.Where(t => t.TrainingId == TrainingId).ToListAsync();
        }

        public Task UpdateTrainingHasExerciseAsync(TrainingHasExercise TrainingHasExercise)
        {
            throw new NotImplementedException();
        }
    }
}
