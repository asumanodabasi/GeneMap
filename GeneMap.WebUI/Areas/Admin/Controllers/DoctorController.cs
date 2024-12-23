using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DoctorController : Controller
    {
        private readonly DoctorRepo _doctorRepo;

        public DoctorController(DoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public IActionResult Index(CancellationToken cancellationToken)
        {
            var result=_doctorRepo.List(cancellationToken);
            return View(result);
        }

        public async Task<IActionResult> Add(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DoctorDto doctorDto, CancellationToken cancellationToken)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View(nameof(Add), doctorDto);
            }
            await _doctorRepo.Add(doctorDto, cancellationToken);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            var result = await _doctorRepo.GetById(id, cancellationToken);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, DoctorDto doctorDto, CancellationToken cancellationToken)
        {
            var result = await _doctorRepo.Update(id, doctorDto, cancellationToken);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hasta güncellenemedi");
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _doctorRepo.Delete(id, cancellationToken);
            if (deleted == null)
            {
                ModelState.AddModelError("", "Hasta silinemedi");
            }
            return RedirectToAction("Index");
        }
    }
}
