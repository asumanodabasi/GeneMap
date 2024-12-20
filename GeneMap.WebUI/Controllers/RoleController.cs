using GeneMap.BLL.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Controllers
{
    public class RoleController(RoleManager<AppRole> roleManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Create(string name,CancellationToken cancellation)
        {
            AppRole appRole = new()
            {
                Name= name,
            };
            IdentityResult result = await roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));

            }
            return NoContent();

        }
    }
}
