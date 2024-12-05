using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface ICardioExerciseService
    {
        Task AddCardioExerciseAsync(CardioExercise CardioExercise);
        Task<Training> GetCardioExerciseByIdAsync(int id);
        Task<IEnumerable<CardioExercise>> GetAllCardioExercisesAsync();
        Task DeleteCardioExerciseAsync(int id);
    }
}
