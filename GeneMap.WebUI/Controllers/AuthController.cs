using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
namespace GeneMap.WebUI.Controllers
{
    public class AuthController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register, CancellationToken cancellationToken)
        {
            AppUser user = new()
            {
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.UserName
            };
            IdentityResult result = await userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return Redirect("/Auth/Login");
            }

            return BadRequest(result.Errors.Select(x => x.Description));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto, CancellationToken cancellationToken)
        {
            AppUser? appuser = await userManager.FindByIdAsync(changePasswordDto.Id.ToString());
            if (appuser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            IdentityResult result = await userManager.ChangePasswordAsync(appuser, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));

            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword(string email, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.FindByEmailAsync(email);
            if (appUser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            string token = await userManager.GeneratePasswordResetTokenAsync(appUser);
            return Ok(new { Token = token });
        }

        [HttpPost("changePasswordToken")]
        public async Task<IActionResult> ChangePasswordUsingToken(ChangePasswordUsingTokenDto passwordDto, CancellationToken cancellationToken)
        {

            AppUser? appUser = await userManager.FindByEmailAsync(passwordDto.Email);
            if (appUser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }
            IdentityResult result = await userManager.ResetPasswordAsync(appUser, passwordDto.Token, passwordDto.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));

            }
            return NoContent();
        }
        

        [HttpGet]
     //[ValidateAntiForgeryToken] // CSRF koruması için
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.UserNameOrEmail || x.UserName == loginDto.UserNameOrEmail, cancellationToken);
            if (appUser == null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(appUser, loginDto.Password, true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Şifre Yanlış!");
                return RedirectToAction(nameof(Login), signInResult);
            }
            // Kullanıcıyı oturum açmış hale getir
            await signInManager.SignInAsync(appUser, isPersistent: false);

            return Redirect("/Home/Index");
        }
    }
}
