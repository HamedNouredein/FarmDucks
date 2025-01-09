using FarmDucks.Models;
using FarmDucks.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmDucks.Controllers
{
    public class FarmController : Controller
    {
        private readonly IFarmService _farmService;

        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        public IActionResult Index()
        {
            var farms = _farmService.GetAllFarm();
            return View(farms);
        }

        public IActionResult Details(int id)
        {
            var farm = _farmService.GetFarmById(id);
            if (farm == null)
            {
                return NotFound();
            }
            return View(farm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Farm farm)
        {
            if (ModelState.IsValid)
            {
                _farmService.AddFarm(farm);
                return RedirectToAction(nameof(Index));
            }
            return View(farm);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var farm = _farmService.GetFarmById(id);
            if (farm == null)
            {
                return NotFound();
            }
            return View(farm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Farm farm)
        {
            if (id != farm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _farmService.UpdateFarm(farm);
                return RedirectToAction(nameof(Index));
            }
            return View(farm);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var farm = _farmService.GetFarmById(id);
            if (farm == null)
            {
                return NotFound();
            }
            return View(farm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var success = _farmService.DeleteFarm(id);
            if (success)
            {
                TempData["Success"] = "Farm deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Unable to delete the farm. Please try again.";
            return RedirectToAction(nameof(Index));
        }
    }
}
