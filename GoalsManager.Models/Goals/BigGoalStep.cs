namespace GoalsManager
{
    public class BigGoalStep
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public required DateTime CompleteDate { get; set; }

        public required BigGoal Goal { get; set; }
    }
}
