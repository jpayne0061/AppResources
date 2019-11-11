using AppResourcesWatcher.Models;
using Microsoft.EntityFrameworkCore;

namespace AppResourcesWatcher
{
    public class MemorySnapShotContext : DbContext
    {
        private readonly string _connString;

        public MemorySnapShotContext(string connString)
        {
            _connString = connString;
        }

        public MemorySnapShotContext()
        {

        }

        public DbSet<MemorySnapshot> MemorySnapshots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_connString);
    }
}
