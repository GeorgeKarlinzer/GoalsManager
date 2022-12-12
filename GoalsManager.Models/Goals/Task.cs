using System.Diagnostics.CodeAnalysis;

namespace GoalsManager
{
    public class Task : TaskBase
    {
        public required DateTime Deadline { get; set; }
        public DateTime? CompleteDate { get; set; }

        [SetsRequiredMembers]
        public Task(ApplicationUser user, string name, string description, DateTime creationDate, DateTime deadline) : base(user, name, description, creationDate)
        {
            Deadline = deadline;
        }

        public Task()
        {
        }
    }
}
