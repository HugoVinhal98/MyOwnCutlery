using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Models {

    public class FabricaContext : DbContext {

        public FabricaContext (DbContextOptions<FabricaContext> options) : base (options) { }

        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<ListaMaquinasOperacao> TipoMaquinas_Operacao { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<TipoMaquina> TipoMaquinas { get; set; }
        public DbSet<LinhaProducao> LinhasProducao { get; set; }
        public DbSet<LinhaProducaoMaquina> LinhasProducaoMaquina { get; set; }
        public DbSet<TipoOperacao> tipoOperacoes { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            modelBuilder.Entity<Operacao> ().OwnsOne (p => p.duracao)
                .Property (p => p.minutos).HasColumnName ("minutos");

            modelBuilder.Entity<Operacao> ().OwnsOne (p => p.duracao)
                .Property (p => p.segundos).HasColumnName ("segundos");

            modelBuilder.Entity<Operacao> ().OwnsOne (p => p.nome)
                .Property (p => p.nome).HasColumnName ("nome");

            modelBuilder.Entity<TipoOperacao> ().OwnsOne (p => p.nome)
                .Property (p => p.nome).HasColumnName ("nome");

            modelBuilder.Entity<TipoMaquina> ().OwnsOne (p => p.descricao)
                .Property (p => p.descricao).HasColumnName ("descricao");

            modelBuilder.Entity<Maquina> ().OwnsOne (p => p.descricao)
                .Property (p => p.descricao).HasColumnName ("Descricao");

            modelBuilder.Entity<Maquina> ().OwnsOne (p => p.marca)
                .Property (p => p.marca).HasColumnName ("Marca");

            modelBuilder.Entity<Maquina> ().OwnsOne (p => p.modelo)
                .Property (p => p.modelo).HasColumnName ("Modelo");

            modelBuilder.Entity<LinhaProducao> ().OwnsOne (p => p.descricao)
                .Property (p => p.descricao).HasColumnName ("Descricao");

            modelBuilder.Entity<TipoOperacao> ().OwnsOne (p => p.ferramenta)
                .Property (p => p.descricao).HasColumnName ("Descricao");

            modelBuilder.Entity<TipoOperacao> ().OwnsOne (p => p.tempoSetup)
                .Property (p => p.tempo).HasColumnName ("tempoSetup");

            base.OnModelCreating (modelBuilder);

        }
    }
}