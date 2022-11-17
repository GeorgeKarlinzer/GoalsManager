using Duende.IdentityServer.EntityFramework.Options;
using GoalsManager;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GoalsManager.Web.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<BigGoal> BigGoals { get; set; }
        public DbSet<BigGoalStep> BigGoalSteps { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<RecurringGoal> RecurringGoals { get; set; }
        public DbSet<RecurringSingleGoal> RecurringSingleGoals { get; set; }

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BigGoal>()
                .HasOne(x => x.User)
                .WithMany(x => x.BigGoals);

            builder.Entity<Goal>()
                .HasOne(x => x.User)
                .WithMany(x => x.Goals);

            builder.Entity<RecurringGoal>()
                .HasOne(x => x.User)
                .WithMany(x => x.RecurringGoals);

            builder.Entity<BigGoalStep>()
                .HasOne(x => x.Goal)
                .WithMany(x => x.Steps);

            builder.Entity<RecurringSingleGoal>()
                .HasOne(x => x.Goal)
                .WithMany(x => x.SingleGoals);
        }
    }
}