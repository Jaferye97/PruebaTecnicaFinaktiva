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

        private void OnBeforeSaving(DateTime localNow)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var keyName = entry.Metadata.FindPrimaryKey()?.Properties.FirstOrDefault()?.Name;
                var keyValue = keyName != null ? entry.Property(keyName).CurrentValue : Guid.Empty;

                switch (entry.State)
                {
                    case EntityState.Added:
                        if(keyValue == null || (Guid)keyValue == Guid.Empty)
                            entry.Property("Id").CurrentValue = Guid.NewGuid();

                        entry.Property("CreatedAt").CurrentValue = localNow;
                        break;

                    case EntityState.Modified:
                        entry.Property("CreatedAt").IsModified = false;
                        break;
                }
            }
        }

        private IEnumerable<EventLogsEntity> GetEventLogOnBeforeSaving(DateTime localNow)
        {
            var eventLogs = new List<EventLogsEntity>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is EventLogsEntity)
                    continue;

                var keyName = entry.Metadata.FindPrimaryKey()?.Properties.FirstOrDefault()?.Name;
                var keyValue = keyName != null ? entry.Property(keyName).CurrentValue : 0;

                var nameTable = entry.Metadata.GetAnnotations()
                          .FirstOrDefault(a => a.Name == "Relational:TableName")?.Value?.ToString();

                switch (entry.State)
                {
                    case EntityState.Added:
                        eventLogs.Add(new EventLogsEntity
                        {
                            EventDate = localNow,
                            Description = $"(INSERT) Nuevo registro en {entry.Entity.GetType().Name}",
                            ReferenceId = (Guid?)keyValue,
                            ReferenceEntity = nameTable,
                            EventType = "API",
                            CreatedAt = localNow
                        });

                        break;

                    case EntityState.Modified:
                        eventLogs.Add(new EventLogsEntity
                        {
                            EventDate = localNow,
                            Description = $"(UPDATE) Actualización en {entry.Entity.GetType().Name}",
                            ReferenceId = (Guid?)keyValue,
                            ReferenceEntity = nameTable,
                            EventType = "API",
                            CreatedAt = localNow
                        });

                        break;
                }
            }

            return eventLogs;
        }

        private void OnAfterSaving(DateTime localNow, IEnumerable<EventLogsEntity> eventLogs)
        {
            if (eventLogs?.Count() > 0)
            {
                EventLog.AddRange(eventLogs);
                base.SaveChanges();
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var localNow = DateTime.Now;

            OnBeforeSaving(localNow);

            var eventLogs = GetEventLogOnBeforeSaving(localNow);

            var result = await base.SaveChangesAsync(cancellationToken);

            OnAfterSaving(localNow, eventLogs);

            return result;
        }

        public DbSet<CustomersEntity> Customer { get; set; }
        public DbSet<EventLogsEntity> EventLog { get; set; }
    }
}
