using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface ITrainerService
    {
        public Task<Trainer> GetTrainerById(int id);
    }
}
