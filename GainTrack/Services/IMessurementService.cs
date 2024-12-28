using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public interface IMessurementService
    {
        public Task<IEnumerable<Messurement>> GetMessurementsAsync();

        public Task CreateMessurement(Messurement messurement);

        public Task<bool> ExistsByName(string name);

        public Task AddNewMessure(UserHasMessurement userHasMessurement);
        public Task<bool> ExistsByNameAndDateAndUser(UserHasMessurement userHasMessurement);
    }
}
