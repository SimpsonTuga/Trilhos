using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Data;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(Trails4HealthDbContext))]
    [Migration("20180117170423_lastday")]
    partial class lastday
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trails4Health.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DifficultyID");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("Trails4Health.Models.Guide", b =>
                {
                    b.Property<int>("GuideId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("NIF")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("GuideId");

                    b.ToTable("Guide");
                });

            modelBuilder.Entity("Trails4Health.Models.GuideTrail", b =>
                {
                    b.Property<int>("GuideId");

                    b.Property<int>("TrailId");

                    b.HasKey("GuideId", "TrailId");

                    b.HasIndex("TrailId");

                    b.ToTable("GuideTrail");
                });

            modelBuilder.Entity("Trails4Health.Models.Trail", b =>
                {
                    b.Property<int>("TrailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DifficultyId");

                    b.Property<int>("Distance");

                    b.Property<string>("Name");

                    b.Property<bool>("State");

                    b.HasKey("TrailsId");

                    b.HasIndex("DifficultyId");

                    b.ToTable("Trail");
                });

            modelBuilder.Entity("Trails4Health.Models.GuideTrail", b =>
                {
                    b.HasOne("Trails4Health.Models.Guide", "Guide")
                        .WithMany("GuideTrail")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trail", "Trail")
                        .WithMany("GuideTrail")
                        .HasForeignKey("TrailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Trail", b =>
                {
                    b.HasOne("Trails4Health.Models.Difficulty", "Difficulty")
                        .WithMany("Trail")
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
