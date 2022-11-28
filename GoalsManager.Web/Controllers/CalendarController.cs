using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoalsManager.Web.Controllers
{
    [ApiController]
    [Authorize]
    public class CalendarController : Controller
    {
        [HttpGet]
        [Route("calendar/")]
        public string Index()
        {
            return string.Empty;
        }
    }
}
