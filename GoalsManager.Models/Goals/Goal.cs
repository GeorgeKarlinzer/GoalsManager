namespace GoalsManager
{
    public class Goal : GoalBase
    {
        public required DateTime Deadline { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}
