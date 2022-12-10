using GoalsManager.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GoalsManager.Web
{
    public static class ControllerExtension
    {
        public static ApplicationUser GetCurrentUser(this Controller controller, ApplicationDbContext context)
        {
            var username = controller.User!.Identity!.Name!;
            var user = context.Users.First(x => x.UserName == username);

            return user;
        }
    }
}
