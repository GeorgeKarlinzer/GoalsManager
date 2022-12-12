using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace GoalsManager
{
    public class Goal : TaskBase
    {
        public required DateTime Deadline { get; set; }

        public List<GoalStep> Steps { get; set; }

        public Goal() : base()
        {
            Steps = new();
        }

        [SetsRequiredMembers]
        public Goal(ApplicationUser user, string name, string description, DateTime creationDate, DateTime deadline) : base(user, name, description, creationDate)
        {
            Deadline = deadline;
            Steps = new();
        }
    }
}
