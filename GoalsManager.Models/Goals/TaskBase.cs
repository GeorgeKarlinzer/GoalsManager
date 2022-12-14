namespace GoalsManager
{
    public abstract class TaskBase
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreationDate { get; set; }
        public bool IsComplete { get; set; }

        public required ApplicationUser User { get; set; }
    }
}
