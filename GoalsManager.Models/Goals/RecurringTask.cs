using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace GoalsManager
{
    public class RecurringTask : TaskBase
    {
        public List<RecurringSingleTask> SingleTasks { get; set; }

        [SetsRequiredMembers]
        public RecurringTask(ApplicationUser user, string name, string description, DateTime creationDate) : base(user, name, description, creationDate)
        {
            SingleTasks = new();
        }

        public RecurringTask() : base()
        {
            SingleTasks = new();
        }
    }
}
