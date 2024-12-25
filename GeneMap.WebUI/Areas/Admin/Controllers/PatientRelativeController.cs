using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Areas.Admin.Controllers
{
    // [Authorize]
    [Area("Admin")]
    public class PatientRelativeController : Controller
    {
        private readonly PatientRelativeRepo _patientRelativeRepo;
        private readonly PatientRepo _patientRepo;
        public PatientRelativeController(PatientRelativeRepo patientRelativeRepo,PatientRepo patientRepo)
        {
            _patientRelativeRepo = patientRelativeRepo;
            _patientRepo = patientRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int patientId,CancellationToken cancellationToken)
        {
            var result = await _patientRepo.GetRelatives(patientId, cancellationToken);
            return PartialView(result);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PatientRelativeDto patientRelativeDto, CancellationToken cancellationToken)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View(nameof(Add), patientRelativeDto);
            }
            await _patientRelativeRepo.Add(patientRelativeDto, cancellationToken);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            var result = await _patientRelativeRepo.GetById(id, cancellationToken);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PatientRelativeDto patientRelativeDto, CancellationToken cancellationToken)
        {
            var result = await _patientRelativeRepo.Update(id, patientRelativeDto, cancellationToken);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hasta güncellenemedi");
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _patientRelativeRepo.Delete(id, cancellationToken);
            if (deleted == null)
            {
                ModelState.AddModelError("", "Hasta silinemedi");
            }
            return RedirectToAction("Index");
        }
    }
}
