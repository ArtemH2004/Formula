using Formula.Data;
using Formula.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Formula.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RaceDbStorage _raceDbStorage;

        public RaceController(ApplicationDbContext context, RaceDbStorage raceDbStorage)
        {
            _context = context;
            _raceDbStorage = raceDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var races = await _raceDbStorage.GetAllRaces();
            return View(races);
        }

        public IActionResult Create()
        {
            var model = new RaceViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RaceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var race = new Race
            {
                Date = model.Date,
                StageNumber = model.StageNumber,
                Type = model.Type,
                Price = model.Price,
                AudienceCount = model.AudienceCount,
                Result = model.Result,
                Weather = model.Weather,
                TrackId = model.TrackId
            };

            await _raceDbStorage.AddRace(race);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var race = await _raceDbStorage.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }

            var model = new RaceViewModel
            {
                RaceId = race.RaceId,
                Date = race.Date,
                StageNumber = race.StageNumber,
                Type = race.Type,
                Price = race.Price,
                AudienceCount = race.AudienceCount,
                Result = race.Result,
                Weather = race.Weather,
                TrackId = race.TrackId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RaceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var race = await _raceDbStorage.GetRaceById(model.RaceId);
            if (race == null)
            {
                return NotFound();
            }

            race.Date = model.Date;
            race.StageNumber = model.StageNumber;
            race.Type = model.Type;
            race.Price = model.Price;
            race.AudienceCount = model.AudienceCount;
            race.Result = model.Result;
            race.Weather = model.Weather;
            race.TrackId = model.TrackId;

            await _raceDbStorage.UpdateRace(race);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _raceDbStorage.DeleteRace(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
