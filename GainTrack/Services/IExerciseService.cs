using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface IExerciseService
    {
        Task AddExerciseAsync(Exercise Exercise);
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();
        Task UpdateExerciseAsync(Exercise Exercise);
        Task DeleteExerciserAsync(int id);
    }
}
