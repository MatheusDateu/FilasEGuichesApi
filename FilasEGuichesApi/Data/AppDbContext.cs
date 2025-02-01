using FilasEGuichesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilasEGuichesApi.Data
{
    public class AppDbContext : DbContext
    {
        #region Construtores

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #endregion

        #region DbSets - Representação das tabelas no banco

        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Guiche> Guiches { get; set; }
        public DbSet<TipoGuiche> TiposGuiche { get; set; }

        #endregion

        #region Na Criação

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir relacionamento entre Ficha e Guiche
            modelBuilder.Entity<Ficha>()
                .HasOne(f => f.Guiche)
                .WithMany(g => g.Fichas)
                .HasForeignKey(f => f.GuicheId);

            // Definir relacionamento entre Guiche e TipoGuiche
            modelBuilder.Entity<Guiche>()
                .HasOne(g => g.TipoGuiche)
                .WithMany(tg => tg.Guiches)
                .HasForeignKey(g => g.TipoGuicheId);

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Mocks

        public void SeedData()
        {
            if (!TiposGuiche.Any()) // Verifica se já existem registros
            {
                TiposGuiche.AddRange(
                    new TipoGuiche { Id = 1, Nome = "Atendimento", Prefixo = "A" },
                    new TipoGuiche { Id = 2, Nome = "Gerencia", Prefixo = "G" }
                );
            }

            if (!Guiches.Any())
            {
                Guiches.AddRange(
                    new Guiche { Id = 1, TipoGuicheId = 1 },
                    new Guiche { Id = 2, TipoGuicheId = 2 }
                );
            }

            SaveChanges();
        }


        #endregion

    }
}
