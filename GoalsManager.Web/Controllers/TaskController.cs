using GoalsManager.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoalsManager.Web.Controllers
{
    [ApiController]
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(Routes.ServerGetTasks)]
        public string GetTasks()
        {
            var user = this.GetCurrentUser(_context);

            var tasks = _context.Tasks.Where(x => x.UserId == user.Id)
                .ToList();

            return tasks.ToJson();
        }

        [HttpPost]
        public IActionResult AddTask([FromBody]Task task)
        {
            return Redirect("");
        }

        [HttpGet]
        [Route(Routes.ServerGetReccuringTasks)]
        public string GetRecurringTasks()
        {
            var user = this.GetCurrentUser(_context);

            var tasks = _context.RecurringTasks.Where(x => x.UserId == user.Id)
                .ToList();

            return tasks.ToJson();
        }
    }
}
