using GoalsManager.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalsManager.Web.Controllers
{
    [ApiController]
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ApplicationUser? _appUser;

        private ApplicationUser AppUser => _appUser ??= this.GetCurrentUser(_context);

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(Routes.ServerGetTasks)]
        public string GetTasks()
        {
            var tasks = _context.Tasks.Where(x => x.UserId == AppUser.Id)
                .ToList();

            return tasks.ToJson();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] Task task)
        {
            task.UserId = AppUser.Id;
            task.User = AppUser;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return Redirect(Routes.ClientTasks);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveTask([FromBody] Task task)
        {
            var dbTask = _context.Tasks.FirstOrDefault(x => x.UserId == AppUser.Id && x.Id == task.Id);

            if(dbTask is not null)
            {
                _context.Tasks.Remove(dbTask);
                await _context.SaveChangesAsync();
            }

            return Redirect(Routes.ClientTasks);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTask([FromBody] Task task)
        {
            var dbTask = _context.Tasks.FirstOrDefault(x => x.UserId == AppUser.Id && x.Id == task.Id);

            if(dbTask is not null)
            {
                dbTask.CompleteDate = task.CompleteDate;
                dbTask.CreationDate = task.CreationDate;
                dbTask.Deadline = task.Deadline;
                dbTask.Description = task.Description;
                dbTask.IsComplete = task.IsComplete;
                dbTask.Name = task.Name;

                await _context.SaveChangesAsync();
            }

            return Redirect(Routes.ClientTasks);
        }
    }
}
