using Formula.Data;
using Formula.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TeamDbStorage _teamDbStorage;

        public TeamController(ApplicationDbContext context, TeamDbStorage teamDbStorage)
        {
            _context = context;
            _teamDbStorage = teamDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _teamDbStorage.GetAllTeams();
            return View(teams);
        }

        public IActionResult Create()
        {
            var model = new TeamViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var team = new Team
            {
                Name = model.Name,
                Country = model.Country,
                RaceId = model.RaceId
            };

            await _teamDbStorage.AddTeam(team);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var team = await _teamDbStorage.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }

            var model = new TeamViewModel
            {
                TeamId = team.TeamId,
                Name = team.Name,
                Country = team.Country,
                RaceId = team.RaceId,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var team = await _teamDbStorage.GetTeamById(model.TeamId);
            if (team == null)
            {
                return NotFound();
            }

            team.Name = model.Name;
            team.Country = model.Country;
            team.RaceId = model.RaceId;

            await _teamDbStorage.UpdateTeam(team);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamDbStorage.DeleteTeam(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
