using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface ITraineeService
    {
        public Task<Trainee> GetTraineeById(int id);

        public Task<IEnumerable<Trainee>> GetTraineeByTrainerId(int id);
    }
}
