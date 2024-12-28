using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GainTrack.Services
{
    public class MessurementService : IMessurementService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public MessurementService(IServiceScopeFactory serviceScopeFactory)
        {
            _scopeFactory = serviceScopeFactory;
        }

        public async Task AddNewMessure(UserHasMessurement userHasMessurement)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                await _context.UserHasMessurements.AddAsync(userHasMessurement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateMessurement(Messurement messurement)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                await _context.Messurements.AddAsync(messurement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByNameAndDateAndUser(UserHasMessurement userHasMessurement)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.UserHasMessurements.AnyAsync(u => u.TraineeId == userHasMessurement.TraineeId && u.MessurementName.Equals(userHasMessurement.MessurementName) && u.Date.Equals(userHasMessurement.Date));
            }
        }

        public async Task<bool> ExistsByName(string name)
        {
            using( var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Messurements.AnyAsync(m => m.Name.Equals(name));
            }
        }

        public async Task<IEnumerable<Messurement>> GetMessurementsAsync()
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Messurements.ToListAsync();
            }
        }

        public async Task<IEnumerable<UserHasMessurement>> GetUserHasMessurementsByTraineeAndMessurement(User Trainee, Messurement messurement)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.UserHasMessurements.Where(uhm => uhm.TraineeId == Trainee.Id && uhm.MessurementName.Equals(messurement.Name)).ToListAsync();
            }
        }
    }
}
