namespace GoalsManager
{
    public class RecurringSingleGoal
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public bool IsComplete { get; set; }
        public required DateTime DeadLine { get; set; }

        public required RecurringGoal Goal { get; set; }
    }
}
