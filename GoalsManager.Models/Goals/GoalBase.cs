﻿namespace GoalsManager
{
    public abstract class GoalBase
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsComplete { get; set; }
        public required DateTime CreationDate { get; set; }
    }
}