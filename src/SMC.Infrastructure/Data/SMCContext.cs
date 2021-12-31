using Microsoft.EntityFrameworkCore;

namespace SMC.Infrastructure.Data
{
    public class SMCContext : DbContext
    {
        public SMCContext(DbContextOptions<SMCContext> options) : base(options)
        {
        }

        public DbSet<Core.Entities.Task> Tasks { get; set; }
    }
}