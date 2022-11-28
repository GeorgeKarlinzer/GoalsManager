namespace GoalsManager
{
    public class GoalStep
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public required DateTime CompleteDate { get; set; }

        public required Goal Goal { get; set; }
    }
}
