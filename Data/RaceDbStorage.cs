using Formula.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula.Data
{
    public class RaceDbStorage
    {
        private readonly ApplicationDbContext _context;

        public RaceDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Race>> GetAllRaces()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race?> GetRaceById(int id)
        {
            return await _context.Races.FindAsync(id);
        }

        public async Task AddRace(Race race)
        {
            _context.Races.Add(race);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRace(Race race)
        {
            _context.Races.Update(race);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRace(int id)
        {
            var race = await _context.Races.FindAsync(id);
            if (race != null)
            {
                _context.Races.Remove(race);
                await _context.SaveChangesAsync();
            }
        }
    }
}
