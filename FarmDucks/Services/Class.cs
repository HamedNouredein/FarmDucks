//// GET: Cycle/Edit
//using FarmDucks.Services;
//using FarmDucks.ViewModels;
//using Microsoft.AspNetCore.Mvc;

//public IActionResult Edit(int id)
//{
//    var cycle = _cycleService.GetCycleById(id);
//    if (cycle == null)
//    {
//        return NotFound(); // إذا لم تجد الدورة
//    }

//    var viewModel = new CycleViewModel
//    {
//        Cycle = cycle,
//        Farms = _farmService.GetAllFarm() // جلب المزارع
//    };
//    return View(viewModel);
//}

//// POST: Cycle/Edit
//[HttpPost]
//[ValidateAntiForgeryToken]
//public IActionResult Edit(int id, CycleViewModel viewModel)
//{
//    if (id != viewModel.Cycle.Id)
//    {
//        return NotFound(); // إذا لم يتطابق المعرف
//    }

//    if (!ModelState.IsValid)
//    {
//        viewModel.Farms = _farmService.GetAllFarm(); // إعادة تحميل المزارع
//        return View(viewModel); // إعادة عرض النموذج مع الأخطاء
//    }

//    _cycleService.UpdateCycle(viewModel.Cycle); // تحديث الدورة
//    return RedirectToAction(nameof(Index)); // إعادة التوجيه إلى صفحة عرض الدورات
//}