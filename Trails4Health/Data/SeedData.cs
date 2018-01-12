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
                new Difficulty { DifficultyID=1, Name = "Amador" },
                new Difficulty { DifficultyID=2, Name = "Casual" },
                new Difficulty { DifficultyID=3, Name = "Experienciado" },
                new Difficulty { DifficultyID=4, Name = "Proficional" }
            );

            dbContext.Trail.AddRange(
                new Trail { TrailsId = 1, Name = "Triho da Beira", Distance = 23845, State = true, DifficultyId = 1 },
                new Trail { TrailsId = 2, Name = "Trilho do Pico", Distance = 27245, State = true, DifficultyId = 3 },
                new Trail { TrailsId = 3, Name = "Trilho da Boca do Inferno", Distance = 19845, State = true, DifficultyId = 3 },
                new Trail { TrailsId = 4, Name = "Trilho Serrano", Distance = 37845, State = true, DifficultyId = 4 },
                new Trail { TrailsId = 5, Name = "Trilho Planalto Laranja", Distance = 21845, State = true, DifficultyId = 2 }
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
