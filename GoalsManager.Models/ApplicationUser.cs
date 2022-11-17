using Microsoft.AspNetCore.Identity;

namespace GoalsManager
{
    public class ApplicationUser : IdentityUser
    {
        public List<BigGoal> BigGoals { get; set; }
        public List<Goal> Goals { get; set; }
        public List<RecurringGoal> RecurringGoals { get; set; }

        public ApplicationUser()
        {
            BigGoals = new();
            Goals = new();
            RecurringGoals = new();
        }
    }
}