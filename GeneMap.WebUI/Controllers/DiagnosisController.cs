using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly DiagnosisRepo _diagnosisRepo;

        public DiagnosisController(DiagnosisRepo diagnosisRepo)
        {
            _diagnosisRepo = diagnosisRepo;
        }

        public IActionResult Index(CancellationToken cancellationToken)
        {
            var result = _diagnosisRepo.List(cancellationToken);
            return View(result);
        }

        public async Task<IActionResult> Add(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DiagnosisDto diagnosisDto, CancellationToken cancellationToken)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View(nameof(Add), diagnosisDto);
            }
            await _diagnosisRepo.Add(diagnosisDto, cancellationToken);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            var result = await _diagnosisRepo.GetById(id, cancellationToken);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, DiagnosisDto diagnosisDto, CancellationToken cancellationToken)
        {
            var result = await _diagnosisRepo.Update(id, diagnosisDto, cancellationToken);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hasta güncellenemedi");
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _diagnosisRepo.Delete(id, cancellationToken);
            if (deleted == null)
            {
                ModelState.AddModelError("", "Hasta silinemedi");
            }
            return RedirectToAction("Index");
        }

    }
}
