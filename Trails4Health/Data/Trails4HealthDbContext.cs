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
        public DbSet<Trails> Trails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            //Relaçoes e modificaçoes da tabela guide (vai ter N para N com a Tabela trilhos)
           // modelBuilder.Entity<Guide>()
               //.HasKey(z => new { z.GuideID});
            //Relação da tabela Trilho
            modelBuilder.Entity<Trails>()
               // .HasKey(x => new { x.TrailId })
                .HasOne(c=>c.Dificulty)
                .WithMany(v=>v.Trails)
                .HasForeignKey(c=>c.DificultyID)

        }
    }
}
