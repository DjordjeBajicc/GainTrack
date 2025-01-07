using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface IUserService
    {
        Task AddUserAndTraineeAsync(User user, int trainerId);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task UpdateUserThemeAndLanguageAsync(User user);
        Task DeleteUserAsync(int id);
        Task UpdateUser(User user);
        Task<bool> CheckAvailabilityOfusername(string username);

    }
}
