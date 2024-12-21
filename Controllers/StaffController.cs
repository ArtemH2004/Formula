using Formula.Data;
using Formula.Models;
using Microsoft.AspNetCore.Mvc;

// TODO Не работает создание сотрудника
namespace Formula.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly StaffDbStorage _staffDbStorage;

        public StaffController(ApplicationDbContext context, StaffDbStorage staffDbStorage)
        {
            _context = context;
            _staffDbStorage = staffDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var staffs = await _staffDbStorage.GetAllStaffs();
            return View(staffs);
        }

        public IActionResult Create()
        {
            var model = new StaffViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var staff = new Staff
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Birthday = model.Birthday,
                Gender = model.Gender,
                Job = model.Job,
                TeamId = model.TeamId
            };

            await _staffDbStorage.AddStaff(staff);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var staff = await _staffDbStorage.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }

            var model = new StaffViewModel
            {
                StaffId = staff.StaffId,
                LastName = staff.LastName,
                FirstName = staff.FirstName,
                Birthday = staff.Birthday,
                Gender = staff.Gender,
                Job = staff.Job,
                TeamId = staff.TeamId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var staff = await _staffDbStorage.GetStaffById(model.StaffId);
            if (staff == null)
            {
                return NotFound();
            }

            staff.LastName = model.LastName;
            staff.FirstName = model.FirstName;
            staff.Birthday = model.Birthday;
            staff.Gender = model.Gender;
            staff.Job = model.Job;
            staff.TeamId = model.TeamId;

            await _staffDbStorage.UpdateStaff(staff);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffDbStorage.DeleteStaff(id);
            return RedirectToAction(nameof(Index));
        }
    }
}