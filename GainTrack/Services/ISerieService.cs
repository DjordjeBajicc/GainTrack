using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface ISerieService
    {
        Task AddSerieAsync(Serie serie);
        Task<Serie> GetSerieByConcreteExerciseOnTrainingTrainingHasExerciseIdAsync(int id);
        Task<IEnumerable<Serie>> GetSerieByConcreteExerciseOnTrainingTrainingHasExerciseIdAndDateAsync(int id, DateOnly date);
        Task<IEnumerable<Serie>> GetAllSeriesOnTrainingsAsync();
    }
}
