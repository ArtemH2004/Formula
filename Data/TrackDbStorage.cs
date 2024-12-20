using Formula.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula.Data
{
    public class TrackDbStorage
    {
        private readonly ApplicationDbContext _context;

        public TrackDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Track>> GetAllTracks()
        {
            return await _context.Tracks.ToListAsync();
        }

        public async Task<Track?> GetTrackById(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        public async Task AddTrack(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTrack(Track track)
        {
            _context.Tracks.Update(track);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrack(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
                await _context.SaveChangesAsync();
            }
        }
    }
}
