using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class SeedData
    {
        private static Trails4HealthDbContext dbContext;
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            dbContext = (Trails4HealthDbContext)serviceProvider.GetService(typeof(Trails4HealthDbContext));
            dbContext.Database.EnsureCreated();

            if (!dbContext.Difficulty.Any())
            {
                EnsureTrailsPopulated(dbContext);
                dbContext.SaveChanges();
            }
        }

        private static void EnsureTrailsPopulated(Trails4HealthDbContext dbContext)
        {
            dbContext.Difficulty.AddRange(
                new Difficulty {  Name = "Amador" },
                new Difficulty {  Name = "Casual" },
                new Difficulty {  Name = "Experienciado" },
                new Difficulty {  Name = "Proficional" }
            );

            dbContext.Trail.AddRange(
                new Trail {  Name = "Triho da Beira", Distance = 23845, State = true, DifficultyId = 1 },
                new Trail {  Name = "Trilho do Pico", Distance = 27245, State = true, DifficultyId = 3 },
                new Trail {  Name = "Trilho da Boca do Inferno", Distance = 19845, State = true, DifficultyId = 3 },
                new Trail {  Name = "Trilho Serrano", Distance = 37845, State = true, DifficultyId = 4 },
                new Trail {  Name = "Trilho Planalto Laranja", Distance = 21845, State = true, DifficultyId = 2 }
            );
       
        }

        public static void AddTrilho(Trail t)
        {
            dbContext.Trail.Add(t);
            dbContext.SaveChanges();
        }

        public static void AddDificuldade(Difficulty d)
        {
            dbContext.Difficulty.Add(d);
            dbContext.SaveChanges();
        }
    }
}
