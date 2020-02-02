using Microsoft.EntityFrameworkCore;
using BookAppWithMysql.Btctalk.Models;
using Microsoft.Extensions.Logging;

namespace BookAppWithMysql.Btctalk
{
    public class BtctalkContext : DbContext
    {
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            .UseMySQL("server=localhost;database=bittalk;user=root;password=;SslMode = none");
            //optionsBuilder.UseSqlite("Data Source=blogging.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forum>().ToTable("forums");
            modelBuilder.Entity<Forum>()
                .HasKey(c => c.FID);

            modelBuilder.Entity<Topic>().ToTable("threads");
            modelBuilder.Entity<Topic>()
                .HasKey(c => new { c.TID, c.FID });

            modelBuilder.Entity<ThreadResponse>().ToTable("threads_responses");
            modelBuilder.Entity<ThreadResponse>()
                .HasKey(c => new { c.TID, c.LastPostDate });

        }
    }
}