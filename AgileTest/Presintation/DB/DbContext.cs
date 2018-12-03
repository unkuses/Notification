using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presintation.DB
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }

        public SqliteDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=notification.db");
        }
    }
}
