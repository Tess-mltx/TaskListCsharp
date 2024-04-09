using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using TaskList.Models;
using TaskList.Models.Entities;

namespace TaskList.Controllers
{
    public class AssignmentsController : Controller
    {
        //Add DbContext for this file
        private readonly ApplicationDbContext dbContext;

        public AssignmentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAssignmentViewModel viewModel)
        {
            var assignment = new Assignment
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Status = viewModel.Status,
                DueDate = viewModel.DueDate,
            };
            await dbContext.Tasks.AddAsync(assignment);
            await dbContext.SaveChangesAsync();


            return RedirectToAction("List", "Assignments");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var assignments = await dbContext.Tasks.ToListAsync();

            return View(assignments);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var assignment = await dbContext.Tasks.FindAsync(id);

            return View(assignment);    
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Assignment viewModel)
        {
            var assignment = await dbContext.Tasks.FindAsync(viewModel.Id);

            if (assignment is not null)
            {
                assignment.Title = viewModel.Title;
                assignment.Description = viewModel.Description;
                assignment.Status = viewModel.Status;
                assignment.DueDate = viewModel.DueDate;

                await dbContext.SaveChangesAsync();

            }

            return RedirectToAction("List", "Assignments");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var assignment = await dbContext.Tasks.FindAsync(id);

            if (assignment is not null )
            {
                dbContext.Tasks.Remove(assignment);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Assignments");

        }
    }
}
