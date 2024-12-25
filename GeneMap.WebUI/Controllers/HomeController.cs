using GeneMap.WebUI.Models;
using GeneMap.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeneMap.WebUI.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LanguageService _language;

        public HomeController(ILogger<HomeController> logger, LanguageService language)
        {
            _logger = logger;
            _language = language;
        }

        public IActionResult Index()
        {
            ViewBag.Welcome = _language.GetKey("Welcome").Value;
            var current = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires=DateTimeOffset.UtcNow.AddDays(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
