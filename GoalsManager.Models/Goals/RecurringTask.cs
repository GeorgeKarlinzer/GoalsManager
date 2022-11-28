namespace GoalsManager
{
    public class RecurringTask : TaskBase
    {
        public List<RecurringSingleTask> SingleTasks { get; set; }

        public RecurringTask()
        {
            SingleTasks = new();
        }
    }
}
