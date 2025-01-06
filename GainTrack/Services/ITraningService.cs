using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface ITraningService
    {
        Task<Training> AddTrainingAsync(Training training);
        Task<Training> GetTrainingByIdAsync(int id);
        Task<IEnumerable<Training>> GetAllTrainingsAsync();
        Task<IEnumerable<Training>> GetAllTrainingsIncludeDeletedAsync(int TraineeId);
        Task UpdateTrainingAsync(Training training);
        Task DeleteTrainingAsync(int id);
        Task<IEnumerable<Training>> GetTrainingsForUserAsync(int userId);
    }
}
