using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface ITrainingHasExerciseService
    {
        Task AddTrainignHasExerciseAsync(TrainingHasExercise TrainingHasExercise);
        Task<TrainingHasExercise> GetTrainingHasExerciseByIdAsync(int TrainingId, int ExerciseId);
        Task<IEnumerable<TrainingHasExercise>> GetTrainingHasExerciseByTrainingIdAsync(int TrainingId);
        Task<IEnumerable<TrainingHasExercise>> GetAllTrainingHasExercisesAsync();

        Task UpdateTrainingHasExerciseAsync(TrainingHasExercise TrainingHasExercise);
        Task DeleteTrainingHasExerciseAsync(int TrainingId, int ExerciseId);
    }
}
