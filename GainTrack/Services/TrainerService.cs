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
    public class TrainerService : ITrainerService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TrainerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task<Trainer> GetTrainerById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.UserId == id);
                return trainer;
            }
        }
    }
}
