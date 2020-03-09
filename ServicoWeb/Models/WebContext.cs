using Microsoft.EntityFrameworkCore;

namespace ServicoWeb.Models {

    public class WebContext : DbContext {

        public WebContext (DbContextOptions<WebContext> options) : base (options) { }

        public DbSet<Utilizador> Utilizadores { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            modelBuilder.Entity<Utilizador> ().OwnsOne (p => p.password)
                .Property (p => p.password).HasColumnName ("password");

            modelBuilder.Entity<Utilizador> ().OwnsOne (p => p.email)
                .Property (p => p.email).HasColumnName ("email");

            modelBuilder.Entity<Utilizador> ().OwnsOne (p => p.numeroUtilizador)
                .Property (p => p.numeroUtilizador).HasColumnName ("numeroUtilizador");

            modelBuilder.Entity<Utilizador> ().OwnsOne (p => p.tipoUtilizador)
                .Property (p => p.tipoUtilizador).HasColumnName ("tipoUtilizador");

            base.OnModelCreating (modelBuilder);

        }
    }
}