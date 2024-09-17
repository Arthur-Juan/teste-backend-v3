using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Data.Domain;

namespace TheatricalPlayersRefactoringKata.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<PerformanceCost> PerformanceCost { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre("comedy"),
                new Genre("tragedy"),
                new Genre("history")

            );
        }
    }
}
