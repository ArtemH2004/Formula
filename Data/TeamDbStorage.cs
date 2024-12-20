using Formula.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula.Data
{
    public class TeamDbStorage
    {
        private readonly ApplicationDbContext _context;

        public TeamDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetTeamById(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task AddTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeam(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }
    }
}
