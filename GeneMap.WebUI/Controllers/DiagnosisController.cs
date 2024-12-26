using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly DiagnosisRepo _diagnosisRepo;
        private readonly IlnessRepo _ilnessRepo;
        public DiagnosisController(DiagnosisRepo diagnosisRepo,IlnessRepo ilnessRepo)
        {
            _diagnosisRepo = diagnosisRepo;
            _ilnessRepo = ilnessRepo;
        }

        public IActionResult Index(CancellationToken cancellationToken)
        {
            var result = _diagnosisRepo.List(cancellationToken);
            return View(result);
        }

        public async Task<IActionResult> Add(int patientId,CancellationToken cancellationToken)
        {

            var model = new DiagnosisDto
            {
                PatientId = patientId
            };
            return PartialView(model);
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
            return RedirectToAction("PutDiagnosis");
        }

        public async Task<IActionResult> PutDiagnosis(CancellationToken cancellationToken)
        {
            
            return View();
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

        [HttpGet]
        public async Task<IActionResult> GetIlness(CancellationToken cancellationToken)
        {
            var result=await _ilnessRepo.List(cancellationToken);
            return PartialView(result);
        }
    }
}
