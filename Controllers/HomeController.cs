using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Security.Claims;
using TaskList.Models;

namespace TaskList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            //var name = result.Principal.FindFirst(ClaimTypes.Name).Value; // Test line
            //return Json(name); // Test line OK

            return View(result);
            //return View(new
            //{
              //  Name = User.Identity.Name,
              //  EmailAddress = User.Claims
              //  .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
            //});
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
