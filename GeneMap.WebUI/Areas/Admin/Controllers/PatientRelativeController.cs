using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PatientRelativeController : Controller
    {
        private readonly PatientRelativeRepo _patientRelativeRepo;

        public PatientRelativeController(PatientRelativeRepo patientRelativeRepo)
        {
            _patientRelativeRepo = patientRelativeRepo;
        }

        public IActionResult Index(CancellationToken cancellationToken)
        {
            var result = _patientRelativeRepo.List(cancellationToken);
            return View(result);
        }

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
