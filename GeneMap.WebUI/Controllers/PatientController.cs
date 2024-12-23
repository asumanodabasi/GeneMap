using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly PatientRepo _patientRepo;

        public PatientController(PatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _patientRepo.List(cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> Add(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PatientDto patientDto, CancellationToken cancellationToken)
        {
            ModelState.Remove("Id");
            if(!ModelState.IsValid)
            {
                return View(nameof(Add),patientDto);
            }
            await _patientRepo.Add(patientDto, cancellationToken);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Update(int id,CancellationToken cancellationToken)
        {
            var result = await _patientRepo.GetById(id,cancellationToken);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,PatientDto patientDto,CancellationToken cancellationToken)
        {
            var result=await _patientRepo.Update(id, patientDto, cancellationToken);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Hasta güncellenemedi");
            }
            return RedirectToAction("Index");  
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var deleted=await _patientRepo.Delete(id, cancellationToken);
            if (deleted == null)
            {
                ModelState.AddModelError("", "Hasta silinemedi");
            }
            return RedirectToAction("Index");
        }
    }
}
