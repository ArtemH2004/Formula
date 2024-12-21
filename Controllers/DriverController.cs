using Formula.Data;
using Formula.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula.Controllers
{
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DriverDbStorage _driverDbStorage;

        public DriverController(ApplicationDbContext context, DriverDbStorage driverDbStorage)
        {
            _context = context;
            _driverDbStorage = driverDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var drivers = await _driverDbStorage.GetAllDrivers();
            return View(drivers);
        }

        public IActionResult Create()
        {
            var model = new DriverViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var driver = new Driver
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Birthday = model.Birthday,
                Gender = model.Gender,
                PodiumCount = model.PodiumCount,
                TeamId = model.TeamId
            };

            if (model.Photo != null && model.Photo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    driver.Photo = memoryStream.ToArray();
                }
            }

            await _driverDbStorage.AddDriver(driver);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var driver = await _driverDbStorage.GetDriverById(id);
            if (driver == null)
            {
                return NotFound();
            }

            var model = new DriverViewModel
            {
                DriverId = driver.DriverId,
                LastName = driver.LastName,
                FirstName = driver.FirstName,
                Birthday = driver.Birthday,
                Gender = driver.Gender,
                PodiumCount = driver.PodiumCount,
                TeamId = driver.TeamId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DriverViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var driver = await _driverDbStorage.GetDriverById(model.DriverId);
            if (driver == null)
            {
                return NotFound();
            }

            driver.LastName = model.LastName;
            driver.FirstName = model.FirstName;
            driver.Birthday = model.Birthday;
            driver.Gender = model.Gender;
            driver.PodiumCount = model.PodiumCount;
            driver.TeamId = model.TeamId;

            if (model.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    driver.Photo = memoryStream.ToArray();
                }
            }

            await _driverDbStorage.UpdateDriver(driver);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _driverDbStorage.DeleteDriver(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
