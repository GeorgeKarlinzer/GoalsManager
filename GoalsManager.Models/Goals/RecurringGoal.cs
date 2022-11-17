namespace GoalsManager
{
    public class RecurringGoal : GoalBase
    {
        public List<RecurringSingleGoal> SingleGoals { get; set; }

        public RecurringGoal()
        {
            SingleGoals = new();
        }
    }
}
