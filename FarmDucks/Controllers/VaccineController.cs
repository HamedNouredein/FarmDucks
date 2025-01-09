using FarmDucks.Models;
using FarmDucks.Services;
using FarmDucks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmDucks.Controllers
{
    public class VaccineController : Controller
    {
        private readonly IVaccineService _vaccineService;
        private readonly ICycleService _cycleService;

        public VaccineController(IVaccineService vaccineService, ICycleService cycleService)
        {
            _vaccineService = vaccineService;
            _cycleService = cycleService;
        }

        // عرض كل اللقاحات
        public IActionResult Index()
        {
            var vaccines = _vaccineService.GetAllVaccines();
            return View(vaccines);
        }

        // تفاصيل لقاح معين
        public IActionResult Details(int id)
        {
            var vaccine = _vaccineService.GetVaccineById(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return View(vaccine);
        }

        // إنشاء لقاح جديد (عرض النموذج)
        public IActionResult Create()
        {
            var viewModel = new VaccineViewModel
            {
                Cycles = _cycleService.GetAllCycles() // الحصول على جميع الدورات
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VaccineViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var vaccine = viewModel.Vaccine;

                // ربط الدورات المختارة باللقاح
                foreach (var cycleId in viewModel.SelectedCycleIds)
                {
                    vaccine.CycleVaccines.Add(new CycleVaccine
                    {
                        VaccineId = vaccine.Id,
                        CycleId = cycleId
                    });
                }

                _vaccineService.AddVaccine(vaccine); // إضافة اللقاح
                return RedirectToAction(nameof(Index));
            }

            viewModel.Cycles = _cycleService.GetAllCycles();
            return View(viewModel);
        }

        // تعديل لقاح (عرض النموذج)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VaccineViewModel viewModel)
        {
            if (id != viewModel.Vaccine.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                viewModel.Cycles = _cycleService.GetAllCycles();
                return View(viewModel);
            }

            _vaccineService.UpdateVaccine(viewModel.Vaccine);
            return RedirectToAction(nameof(Index));
        }

        // عرض صفحة الحذف
        public IActionResult Delete(int id)
        {
            var vaccine = _vaccineService.GetVaccineById(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return View(vaccine);
        }

        // حذف اللقاح
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _vaccineService.DeleteVaccine(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
