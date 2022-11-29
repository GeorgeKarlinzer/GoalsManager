using Duende.IdentityServer.EntityFramework.Options;
using GoalsManager;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GoalsManager.DataAccess
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalStep> GoalSteps { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<RecurringTask> RecurringTasks { get; set; }
        public DbSet<RecurringSingleTask> RecurringSingleTasks { get; set; }

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Goal>()
                .HasOne(x => x.User)
                .WithMany(x => x.Goals)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Task>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.UserId);

            builder.Entity<RecurringTask>()
                .HasOne(x => x.User)
                .WithMany(x => x.RecurringTasks)
                .HasForeignKey(x => x.UserId);

            builder.Entity<GoalStep>()
                .HasOne(x => x.Goal)
                .WithMany(x => x.Steps)
                .HasForeignKey(x => x.GoalId);

            builder.Entity<RecurringSingleTask>()
                .HasOne(x => x.Task)
                .WithMany(x => x.SingleTasks)
                .HasForeignKey(x => x.TaskId);
        }
    }
}