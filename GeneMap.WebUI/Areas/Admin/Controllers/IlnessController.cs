using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Areas.Admin.Controllers
{
    public class IlnessController : Controller
    {
        private readonly IlnessRepo _ilnessRepo;
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _ilnessRepo.List(cancellationToken);
            return PartialView(result);
        }
    }
}
