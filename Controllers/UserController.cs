using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using TaskList.Models;
using TaskList.Models.Entities;

namespace TaskList.Controllers
{
    public class UserController : Controller
    {
        //Add DbContext for this file
        private readonly ApplicationDbContext dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: UserController
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var user = new User
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                RoleId = 2
                //Password = viewModel.Password,
                //PasswordConfirmation = viewModel.PasswordConfirmation,
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            //return RedirectToAction("index");
            return RedirectToAction("List", "Assignments");



        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
