using GainTrack.Data;
using GainTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTrack.Services
{
    public class CardioExerciseService : ICardioExerciseService
    {
        private GainTrackContext _context;

        public CardioExerciseService(GainTrackContext context)
        {
            _context = context;
        }
        public async Task AddCardioExerciseAsync(CardioExercise CardioExercise)
        {
            _context.CardioExercises.Add(CardioExercise);
            await _context.SaveChangesAsync();
        }

        public Task DeleteCardioExerciseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CardioExercise>> GetAllCardioExercisesAsync()
        {
            return await _context.CardioExercises.ToListAsync();
        }

        public Task<Training> GetCardioExerciseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
