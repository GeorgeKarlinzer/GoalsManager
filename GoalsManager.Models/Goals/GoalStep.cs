using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace GoalsManager
{
    public class GoalStep
    {
        public int Id { get; set; }
        public required int GoalId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompleteDate { get; set; }

        [JsonIgnore]
        public required Goal Goal { get; set; }

        [SetsRequiredMembers]
        public GoalStep(Goal goal)
        {
            Goal = goal;
            GoalId = goal.Id;
        }

        public GoalStep()
        {
        }
    }
}
