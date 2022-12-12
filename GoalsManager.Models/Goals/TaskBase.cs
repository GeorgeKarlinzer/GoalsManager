using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace GoalsManager
{
    public abstract class TaskBase
    {
        public int Id { get; set; }
        [JsonIgnore]
        public required string UserId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreationDate { get; set; }
        public bool IsComplete { get; set; }

        [JsonIgnore]
        public required ApplicationUser User { get; set; }

        [SetsRequiredMembers]
        public TaskBase(ApplicationUser user, string name, string description, DateTime creationDate)
        {
            UserId = user.Id;
            User = user;
            Name = name;
            Description = description;
            CreationDate = creationDate;
        }

        public TaskBase()
        {
        }
    }
}
