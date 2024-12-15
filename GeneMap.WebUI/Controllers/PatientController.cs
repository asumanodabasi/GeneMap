using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Controllers
{
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
            var result=await _patientRepo.Add(patientDto, cancellationToken);
            return View(result);
        }
    }
}
