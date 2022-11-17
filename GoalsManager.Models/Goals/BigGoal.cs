namespace GoalsManager.Models.Goals
{
    public class BigGoal : GoalBase
    {
        public DateTime Deadline { get; set; }
    }

    public class BigGoalStep
    {
        public int GoalId { get; set; }
        public required DateTime CompleteDate { get; set; }

        public required BigGoal Goal { get; set; }
    }
}
