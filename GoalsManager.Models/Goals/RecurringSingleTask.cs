namespace GoalsManager
{
    public class RecurringSingleTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public bool IsComplete { get; set; }
        public required DateTime DeadLine { get; set; }

        public required RecurringTask Task { get; set; }
    }
}
