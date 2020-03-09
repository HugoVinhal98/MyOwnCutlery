using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.EntityFrameworkCore;
using ProducaoApi.DTOs;

namespace ProducaoApi.Models {
    public class ProducaoContext : DbContext {
        public ProducaoContext (DbContextOptions<ProducaoContext> options) : base (options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PlanoFabrico> PlanosFabrico { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            modelBuilder.Entity<Produto> ().OwnsOne (p => p.nome)
                .Property (p => p.nome).HasColumnName ("nome");

            modelBuilder.Entity<Produto> ().OwnsOne (p => p.descricao)
                .Property (p => p.descricao).HasColumnName ("descricao");

            modelBuilder.Entity<Produto> ().OwnsOne (p => p.planoFabrico)
                .Property (p => p.nome).HasColumnName ("planoFabrico");

            modelBuilder.Entity<PlanoFabrico> ().OwnsOne (p => p.nome)
                .Property (p => p.nome).HasColumnName ("nome");

            modelBuilder.Entity<PlanoFabrico> ().HasMany (p => p.listaOperacoes);

            base.OnModelCreating (modelBuilder);
        }
    }
}