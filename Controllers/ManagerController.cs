using Formula.Data;
using Formula.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ManagerDbStorage _managerDbStorage;

        public ManagerController(ApplicationDbContext context, ManagerDbStorage managerDbStorage)
        {
            _context = context;
            _managerDbStorage = managerDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var managers = await _managerDbStorage.GetAllManagers();
            return View(managers);
        }

        public IActionResult Create()
        {
            var model = new ManagerViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var manager = new Manager
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                Type = model.Type,
                Percent = model.Percent,
                TeamId = model.TeamId
            };

            await _managerDbStorage.AddManager(manager);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var manager = await _managerDbStorage.GetManagerById(id);
            if (manager == null)
            {
                return NotFound();
            }

            var model = new ManagerViewModel
            {
                ManagerId = manager.ManagerId,
                LastName = manager.LastName,
                FirstName = manager.FirstName,
                MiddleName = manager.MiddleName,
                Type = manager.Type,
                Percent = manager.Percent,
                TeamId = manager.TeamId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var manager = await _managerDbStorage.GetManagerById(model.ManagerId);
            if (manager == null)
            {
                return NotFound();
            }

            manager.LastName = model.LastName;
            manager.FirstName = model.FirstName;
            manager.MiddleName = model.MiddleName;
            manager.Type = model.Type;
            manager.Percent = model.Percent;
            manager.TeamId = model.TeamId;

            await _managerDbStorage.UpdateManager(manager);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _managerDbStorage.DeleteManager(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
