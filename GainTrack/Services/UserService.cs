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
    public class UserService : IUserService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public UserService(IServiceScopeFactory scopeFactory) { 
            _scopeFactory = scopeFactory;
        }
        public async Task AddUserAsync(User user)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
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
                    _context.Users.Remove(existingUser);
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

        public async Task UpdateUserAsync(User user)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                var existingUSer = await _context.Users.FindAsync(user.Id);
                if (existingUSer != null)
                {
                    existingUSer.Firstname = user.Firstname;
                    existingUSer.Lastname = user.Lastname;
                    existingUSer.Trainer = user.Trainer;

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
