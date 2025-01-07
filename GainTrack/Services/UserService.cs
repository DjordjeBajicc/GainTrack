using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GainTrack.Services
{
    public class UserService : IUserService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public UserService(IServiceScopeFactory scopeFactory) { 
            _scopeFactory = scopeFactory;
        }
        public async Task AddUserAndTraineeAsync(User user, int trainerId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                Trainee trainee = new Trainee
                {
                    UserId = user.Id,
                    TrainerId = trainerId
                };
                await _context.Trainees.AddAsync(trainee);
                await _context.SaveChangesAsync();
            }  
        }

        public async Task<bool> CheckAvailabilityOfusername(string username)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Users.AnyAsync(u => u.Username == username);

            }
        }

        public async Task DeleteUserAsync(int id)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                var existingUser = await _context.Users.FindAsync(id);

                if (existingUser != null)
                {
                    existingUser.Deleted = 1;
                    _context.Users.Update(existingUser);
                    await _context.SaveChangesAsync();
                }
            }
            
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Users.ToListAsync();
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            using( var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Users.FindAsync(id);
            }
        }

        public async Task UpdateUserThemeAndLanguageAsync(User user)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                var existingUSer = await _context.Users.FindAsync(user.Id);
                if (existingUSer != null)
                {
                    existingUSer.Theme = user.Theme;
                    existingUSer.Language = user.Language;

                    await _context.SaveChangesAsync();
                }
            }
             
        }

        async Task<IEnumerable<User>> IUserService.GetAllUsersAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Users.ToListAsync();
            }
                
        }

    }
}
