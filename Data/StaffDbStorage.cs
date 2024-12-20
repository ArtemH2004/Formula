using Formula.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula.Data
{
    public class StaffDbStorage
    {
        private readonly ApplicationDbContext _context;

        public StaffDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Staff>> GetAllStaffs()
        {
            return await _context.Staffs.ToListAsync();
        }

        public async Task<Staff?> GetStaffById(int id)
        {
            return await _context.Staffs.FindAsync(id);
        }

        public async Task AddStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStaff(Staff staff)
        {
            _context.Staffs.Update(staff);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }
    }
}
