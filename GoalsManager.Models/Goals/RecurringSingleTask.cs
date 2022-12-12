using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace GoalsManager
{
    public class RecurringSingleTask
    {
        public int Id { get; set; }
        public required int TaskId { get; set; }
        public bool IsComplete { get; set; }
        public required DateTime Deadline { get; set; }


        [JsonIgnore]
        public required RecurringTask Task { get; set; }

        [SetsRequiredMembers]
        public RecurringSingleTask(DateTime deadline, RecurringTask task)
        {
            Deadline = deadline;
            TaskId = task.Id;
            Task = task;
        }

        public RecurringSingleTask()
        {
        }
    }
}
