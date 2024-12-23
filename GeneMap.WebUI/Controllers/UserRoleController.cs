using GeneMap.BLL.Data;
using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeneMap.WebUI.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRoleController(UserManager<AppUser> userManager) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create(Guid userId,string roleName,CancellationToken cancellationToken)
        {

            AppUser? appUser = await userManager.FindByIdAsync(userId.ToString());
            if (appUser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            IdentityResult result = await userManager.AddToRoleAsync(appUser,roleName);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent() ;
        }
    }
}
