using FarmDucks.Models;
using FarmDucks.Services;
using FarmDucks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmDucks.Controllers
{
    public class CycleController : Controller
    {
        private readonly ICycleService _cycleService;
        private readonly IFarmService _farmService;

        public CycleController(ICycleService cycleService, IFarmService farmService)
        {
            _cycleService = cycleService;
            _farmService = farmService;
        }

        public IActionResult Index()
        {
            var cycles = _cycleService.GetAllCycles();
            return View(cycles);
        }
        public IActionResult Details(int id)
        {
            var cycle = _cycleService.GetCycleById(id);
            if (cycle == null)
            {
                return NotFound();
            }
            return View(cycle);
        }
        public IActionResult Create()
        {
            var viewModel = new CycleViewModel
            {
                Cycle = new Cycle(),
                Farms = _farmService.GetAllFarm()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CycleViewModel viewModel)
        {
           
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); 
                }

                
                viewModel.Farms = _farmService.GetAllFarm();
                return View(viewModel);
            }

            
            _cycleService.AddCycle(viewModel.Cycle);

           
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Edit(int id)
        {
            var cycle = _cycleService.GetCycleById(id);
            if (cycle == null)
            {
                return NotFound(); // إذا لم تجد الدورة
            }

            var viewModel = new CycleViewModel
            {
                Cycle = cycle,
                Farms = _farmService.GetAllFarm() // جلب المزارع
            };
            return View(viewModel);
        }

        // POST: Cycle/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CycleViewModel viewModel)
        {
            if (id != viewModel.Cycle.Id)
            {
                return NotFound(); // إذا لم يتطابق المعرف
            }

            if (!ModelState.IsValid)
            {
                viewModel.Farms = _farmService.GetAllFarm(); // إعادة تحميل المزارع
                return View(viewModel); // إعادة عرض النموذج مع الأخطاء
            }

            _cycleService.UpdateCycle(viewModel.Cycle); // تحديث الدورة
            return RedirectToAction(nameof(Index)); // إعادة التوجيه إلى صفحة عرض الدورات
        }


        public IActionResult Delete(int id)
        {
            var cycle = _cycleService.GetCycleById(id);
            if (cycle == null)
            {
                return NotFound();
            }
            return View(cycle);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _cycleService.DeleteCycle(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
