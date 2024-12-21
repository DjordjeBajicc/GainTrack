using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface IConcreteExerciseOnTrainingService
    {
        Task AddConcreteExerciseOnTrainingAsync(ConcreteExerciseOnTraining concreteExerciseOnTraining);
        Task<ConcreteExerciseOnTraining> GetConcreteExerciseOnTrainingByTrainingHasExerciseIdAsync(int id);
        Task<IEnumerable<ConcreteExerciseOnTraining>> GetAllConcreteExercisesOnTrainingsAsync();
        
    }
}
