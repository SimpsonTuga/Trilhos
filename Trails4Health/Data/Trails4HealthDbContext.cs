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
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<Trail> Trail { get; set; }
        public DbSet<GuideTrail> GuideTrail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FK dificuldade no trail
            modelBuilder.Entity<Trail>()
                .HasOne(t => t.Difficulty)
                .WithMany(d => d.Trail)
                .HasForeignKey(t => t.DifficultyId);
            //PK composta
            modelBuilder.Entity<GuideTrail>()
                .HasKey(k => new { k.GuideId, k.TrailId });
            //relaçao guide para guidetrail
            modelBuilder.Entity<GuideTrail>()
                .HasOne(gt => gt.Guide)
                .WithMany(gt => gt.GuideTrail)
                .HasForeignKey(gt => gt.GuideId);
            //relaçao trail para guidetrail
            modelBuilder.Entity<GuideTrail>()
                .HasOne(gt => gt.Trail)
                .WithMany(gt => gt.GuideTrail)
                .HasForeignKey(gt => gt.TrailId);
            
        }
    }
}
