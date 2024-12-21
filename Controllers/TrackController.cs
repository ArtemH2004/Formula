using Formula.Data;
using Formula.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula.Controllers
{
    public class TrackController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TrackDbStorage _trackDbStorage;

        public TrackController(ApplicationDbContext context, TrackDbStorage trackDbStorage)
        {
            _context = context;
            _trackDbStorage = trackDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var tracks = await _trackDbStorage.GetAllTracks();
            return View(tracks);
        }

        public IActionResult Create()
        {
            var model = new TrackViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var track = new Track
            {
                Type = model.Type,
                Capacity = model.Capacity,
                Address = model.Address,
                RaceId = model.RaceId
            };

            if (model.Photo != null && model.Photo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    track.Photo = memoryStream.ToArray();
                }
            }

            await _trackDbStorage.AddTrack(track);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var track = await _trackDbStorage.GetTrackById(id);
            if (track == null)
            {
                return NotFound();
            }

            var model = new TrackViewModel
            {
                TrackId = track.TrackId,
                Type = track.Type,
                Capacity = track.Capacity,
                Address = track.Address,
                RaceId = track.RaceId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TrackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var track = await _trackDbStorage.GetTrackById(model.TrackId);
            if (track == null)
            {
                return NotFound();
            }

            track.Type = model.Type;
            track.Capacity = model.Capacity;
            track.Address = model.Address;
            track.RaceId = model.RaceId;

            if (model.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    track.Photo = memoryStream.ToArray();
                }
            }

            await _trackDbStorage.UpdateTrack(track);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _trackDbStorage.DeleteTrack(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
