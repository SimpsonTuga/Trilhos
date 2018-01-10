using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Data
{
    public class SeedData
    {/*
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
                new Dificuldade { Name = "Fácil" },
                new Dificuldade { Nome = "Normal" },
                new Dificuldade { Nome = "Difícil" },
                new Dificuldade { Nome = "Extremo" }
            );

            dbContext.Trail.AddRange(
                new Trilho { Name = "Trilho Roteiro", Distance = "Igreja", State = "Roteiro" DifficultyId="1"},
                new Trilho { Nome_Trilho = "Trilho Serra", Local_Partida = "Avenida XX", Local_Chegada = "Torre", Distancia = 65, Tempo = 35, Sugerido_Professor = true, Sugerido_Turista = false, Fechado = false, Epoca_AconselhadaID = 2, Tipo_PercursoID = 1, DificuldadeID = 2 }
                );

            dbContext.Turistas.AddRange(
             new Turista { Nome = "António", Numero_Utente_Saude = "123456789", Cartao_Cidadao = "987654321", Data_Nascimento = DateTime.Parse("02-05-1996"), Email = "antonio@hotmail.com", Morada = "Rua XPTO", NIF = "987652314", Profissao = "Professor", Contacto = "968532147" },
                new Turista { Nome = "Maria", Numero_Utente_Saude = "852656789", Cartao_Cidadao = "785634221", Data_Nascimento = DateTime.Parse("15-05-1987"), Email = "maria@gmail.com", Morada = "Rua BRRR", NIF = "369852314", Profissao = "Advogadp", Contacto = "925692147" }
           );

            dbContext.Tipos_Percursos.AddRange(
             new Tipo_Percurso { Nome = "Paralelos" },
              new Tipo_Percurso { Nome = "Alcatrão" },
               new Tipo_Percurso { Nome = "Terra Batida" }
               );

            dbContext.Associacoes.AddRange(
             new Associacao { Nome = "Manteigas", Objetivos = "Percorrer trilhos no nível fácil" },
               new Associacao { Nome = "Guarda", Objetivos = "Percorrer trilhos no nível normal" }
               );


            dbContext.Reservas.AddRange(
             new Reserva { Data_Reserva = DateTime.Parse("01/11/2017"), Data_Inicio_Trilho = DateTime.Parse("31/12/2017"), Hora_Inicio_Trilho = "15h00", GrupoID = 1, GuiaID = 2, TrilhoID = 1, Realizado = true },
               new Reserva { Data_Reserva = DateTime.Parse("25/10/2017"), Data_Inicio_Trilho = DateTime.Parse("09/11/2017"), Hora_Inicio_Trilho = "10h00", GrupoID = 2, GuiaID = 1, TrilhoID = 1, Realizado = true }
               );


            dbContext.Guias.AddRange(
           new Guia { Nome = "joao", Morada = "rua do pty", Email = "joao@hotmail.com", Data_Nascimento = DateTime.Parse("12/05/1986"), Telemovel = 968532147, Profissao = "Professor Desporto", Historial_Clinico = "Sem antecedentes", Cartao_Cidadao = "", Estado_Civil = "Casado", NIB = 112225585277, NIF = 123654789, Numero_Utente_Saude = 96853214 }
           );

        }

        public static void AddTrilho(Trilho t)
        {
            dbContext.Trilhos.Add(t);
            dbContext.SaveChanges();
        }

        public static void AddDificuldade(Dificuldade dif)
        {
            dbContext.Dificuldades.Add(dif);
            dbContext.SaveChanges();
        }*/
    }
}
