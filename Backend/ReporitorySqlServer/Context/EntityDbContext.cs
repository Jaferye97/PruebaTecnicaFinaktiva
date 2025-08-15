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

        public DbSet<CustomersEntity> Customer { get; set; }
        public DbSet<EventLogsEntity> EventLog { get; set; }
    }
}
