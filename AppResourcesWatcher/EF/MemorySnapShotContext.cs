using AppResourcesWatcher.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AppResourcesWatcher
{
    public class MemorySnapShotContext : DbContext
    {
        public DbSet<MemorySnapshot> MemorySnapshots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connString = configuration.GetConnectionString("AppDb");

            options.UseSqlServer(connString);
        }
            
    }
}
