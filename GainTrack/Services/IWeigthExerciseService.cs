using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface IWeigthExerciseService
    {
        Task AddWeightExerciseAsync(WeightExercise weightExercise);
        Task<Training> GetWeightExerciseByIdAsync(int id);
        Task<IEnumerable<WeightExercise>> GetAllWeightExercisesAsync();
        Task DeleteWeightExerciseAsync(int id);
    }
}
