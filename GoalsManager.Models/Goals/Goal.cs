namespace GoalsManager
{
    public class Goal : TaskBase
    {
        public DateTime Deadline { get; set; }

        public List<GoalStep> Steps { get; set; }

        public Goal()
        {
            Steps = new();
        }
    }
}
