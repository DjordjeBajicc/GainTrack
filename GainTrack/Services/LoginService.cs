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
    public class LoginService : ILoginService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public LoginService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            
        }
        public async Task<User> Login(string username, string password)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GainTrackContext>();
                return await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username) && u.Password != null && u.Password.Equals(password));
            }
        }
    }
}
