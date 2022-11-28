using Microsoft.AspNetCore.Identity;

namespace GoalsManager
{
    public class ApplicationUser : IdentityUser
    {
        public List<Goal> Goals { get; set; }
        public List<Task> Tasks { get; set; }
        public List<RecurringTask> RecurringTasks { get; set; }

        public ApplicationUser()
        {
            Goals = new();
            Tasks = new();
            RecurringTasks = new();
        }
    }
}