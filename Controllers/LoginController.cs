using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TaskList.Models;
using TaskList.Models.Entities;
using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using Microsoft.AspNetCore.Identity;

namespace TaskList.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task Login()
        {
        var authProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            };

            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, authProperties);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            try
            {
                var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
                var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

                var user = new RegisterViewModel
                {
                    Name = result.Principal.FindFirst(ClaimTypes.Name).Value,
                    Email = result.Principal.FindFirst(ClaimTypes.Email).Value,
                    RoleId = 2,
                };

                //await dbContext.Users.AddAsync(user);
                //await dbContext.SaveChangesAsync();

                //return RedirectToAction("index", "Home", new { area = "" });


                //var name = result.Principal.FindFirst(ClaimTypes.Name).Value; // Test line OK
                //return Json(user); // Test line OK
                return RedirectToAction("RegisterUser", "User", user );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred {ex}");
            }
            
        }

    }
}
