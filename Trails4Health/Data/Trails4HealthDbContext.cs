using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;
namespace Trails4Health.Data
{
    public class Trails4HealthDbContext : DbContext
    {
        public Trails4HealthDbContext(DbContextOptions<Trails4HealthDbContext> options) : base(options) { }

        public DbSet<Guide> Guide { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guide>()
               .HasKey(z => new { z.IdGuide});
        }
    }
}
