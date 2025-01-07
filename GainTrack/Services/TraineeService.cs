using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public class TraineeService : ITraineeService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TraineeService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public Task<Trainee> GetTraineeById(int id)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return  _context.Trainees.FirstOrDefaultAsync(t => t.UserId == id);
            }
        }

        public async Task<IEnumerable<Trainee>> GetTraineeByTrainerId(int id)
        {
            using( var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                var trainees = await _context.Trainees.Include(t => t.User).Where(t => t.TrainerId == id && t.User.Deleted == 0).ToListAsync();
                return trainees;
            }
        }
    }
}
