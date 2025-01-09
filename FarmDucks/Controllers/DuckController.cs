using FarmDucks.Services;
using FarmDucks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmDucks.Controllers
{
    public class DuckController : Controller
    {
        private readonly IDuckService _duckService; 
        private readonly ICycleService _cycleService; 

        public DuckController(IDuckService duckService, ICycleService cycleService)
        {
            _duckService = duckService;
            _cycleService = cycleService;
        }
        public IActionResult Index()
        {
            var ducks = _duckService.GetAllDucks();
            return View(ducks);
        }
        public IActionResult Details(int id)
        {
            var duck = _duckService.GetDuckById(id);
            if (duck == null)
            {
                return NotFound();
            }
            return View(duck);
        }
        public IActionResult Create()
        {
            var viewModel = new DuckViewModel
            {
                Cycles = _cycleService.GetAllCycles() 
            };

            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DuckViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // في حالة وجود أخطاء في الـ ModelState، قم بتسجيل الأخطاء
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // أو يمكنك استخدام Logger لكتابة الأخطاء
                }
                viewModel.Cycles = _cycleService.GetAllCycles();
                //return View(viewModel);
                
            }
            _duckService.AddDuck(viewModel.Duck);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var duck = _duckService.GetDuckById(id);
            if (duck == null)
            {
                return NotFound();
            }

            var viewModel = new DuckViewModel
            {
                Duck = duck,
                Cycles = _cycleService.GetAllCycles() 
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DuckViewModel viewModel)
        {
            if (id != viewModel.Duck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _duckService.UpdateDuck(viewModel.Duck);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Cycles = _cycleService.GetAllCycles();
            return View(viewModel);
        }
        public IActionResult Delete(int id)
        {
            var duck = _duckService.GetDuckById(id);
            if (duck == null)
            {
                return NotFound();
            }
            return View(duck);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _duckService.DeleteDuck(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

