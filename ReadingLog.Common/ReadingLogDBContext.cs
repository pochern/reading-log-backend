using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReadingLog.Common.EFModels;
using OperatingSystem = ReadingLog.Common.Helpers.OperatingSystem;

namespace ReadingLog.Common
{
    public partial class ReadingLogDBContext : DbContext
    {
        public ReadingLogDBContext()
        {
        }

        public ReadingLogDBContext(DbContextOptions<ReadingLogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (optionsBuilder.IsConfigured) return;
            var config = new ConfigurationBuilder()
                .AddYamlFile("appsettings.yml")
                .AddEnvironmentVariables().Build();

            var connectionString = string.Empty;
            if (OperatingSystem.IsWindows())
            {
                connectionString = config.GetConnectionString("windowsConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                connectionString = config.GetConnectionString("unixConnectionString");
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 12)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
