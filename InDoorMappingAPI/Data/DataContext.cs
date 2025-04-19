using InDoorMappingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Acessibilidade> Acessibilidade { get; set; }
        public DbSet<Beacon> Beacons { get; set; }
        public DbSet<Caminho> Caminhos { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Mobilidade> Mobilidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Infraestrutura> Infraestruturas { get; set; }
        public DbSet<ComandoEpoc> ComandosEpoc { get; set; }
        public DbSet<Diario> Diario { get; set; }
        public DbSet<FeedbackCaminho> FeedbackCaminhos { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=tassi-t1-5318.jxf.gcp-europe-west1.cockroachlabs.cloud;Port=26257;Userid=1240605;Password=AdminDB;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;SslMode=Disable;Database=defaultdb;SSL Mode=Require");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Mobilidade>()
                .HasIndex(m => m.Tipo)
                .IsUnique();
            // Relação com Origem
            modelBuilder.Entity<Caminho>()
                .HasOne(c => c.Origem)
                .WithMany(i => i.CaminhosOrigem)
                .HasForeignKey(c => c.OrigemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relação com Destino
            modelBuilder.Entity<Caminho>()
                .HasOne(c => c.Destino)
                .WithMany(i => i.CaminhosDestino)
                .HasForeignKey(c => c.DestinoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relação com Acessibilidade
            modelBuilder.Entity<Caminho>()
                .HasOne(c => c.Acessibilidade)
                .WithMany(a => a.Caminhos)
                .HasForeignKey(c => c.AcessibilidadeId)
                .OnDelete(DeleteBehavior.SetNull); // ou Restrict

        }
    }
}
