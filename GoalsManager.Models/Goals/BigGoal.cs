namespace GoalsManager
{
    public class BigGoal : GoalBase
    {
        public DateTime Deadline { get; set; }

        public List<BigGoalStep> Steps { get; set; }

        public BigGoal()
        {
            Steps = new();
        }
    }
}
