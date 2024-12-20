using Formula.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula.Data
{
    public class ManagerDbStorage
    {
        private readonly ApplicationDbContext _context;

        public ManagerDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manager>> GetAllManagers()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<Manager?> GetManagerById(int id)
        {
            return await _context.Managers.FindAsync(id);
        }

        public async Task AddManager(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateManager(Manager manager)
        {
            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager != null)
            {
                _context.Managers.Remove(manager);
                await _context.SaveChangesAsync();
            }
        }
    }
}
