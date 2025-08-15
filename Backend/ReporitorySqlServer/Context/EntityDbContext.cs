using Microsoft.EntityFrameworkCore;
using ReporitorySqlServer.Entities;

namespace ReporitorySqlServer.Context
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext()
        {
        }

        public EntityDbContext(DbContextOptions<EntityDbContext> options)
        : base(options)
        { }

        private void OnBeforeSaving()
        {
            var localNow = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("CreatedAt").CurrentValue = localNow;
                        break;
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<CustomersEntity> Customer { get; set; }
        public DbSet<EventLogsEntity> EventLog { get; set; }
    }
}
