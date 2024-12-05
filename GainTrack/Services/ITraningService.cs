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
        Task AddTrainingAsync(Training training);
        Task<Training> GetTrainingByIdAsync(int id);
        Task<IEnumerable<Training>> GetAllTrainingsAsync();
        Task UpdateTrainingAsync(Training training);
        Task DeleteTrainingAsync(int id);
        Task<IEnumerable<Training>> GetTrainingsForUserAsync(int userId);
    }
}
