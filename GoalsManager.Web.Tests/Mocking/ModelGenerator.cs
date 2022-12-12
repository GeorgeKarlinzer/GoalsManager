using GoalsManager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalsManager.Web.Tests.Mocking
{
    internal class ModelGenerator
    {
        public static List<ApplicationUser> CreateUsers(int count)
        {
            var users = new List<ApplicationUser>();

            for (int i = 0; i < count; i++)
            {
                var user = new ApplicationUser()
                {
                    UserName = $"User {i}"
                };

                users.Add(user);
            }

            return users;
        }

        public static Task CreateTask(ApplicationUser user)
        {
            var task = new Task(user, string.Empty, string.Empty, default, default);

            return task;
        }
    }
}
