namespace GoalsManager
{
    public class Task : TaskBase
    {
        public required DateTime Deadline { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}
