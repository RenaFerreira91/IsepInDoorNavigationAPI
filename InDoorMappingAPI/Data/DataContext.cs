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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=tassi-t1-5318.jxf.gcp-europe-west1.cockroachlabs.cloud;Port=26257;Userid=1240605;Password=AdminDB;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;SslMode=Disable;Database=defaultdb;SSL Mode=Require");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Mobilidade>()
                .HasIndex(m => m.Tipo)
                .IsUnique();

            modelBuilder.Entity<Beacon>()
                .HasMany(b => b.CaminhosOrigem)
                .WithOne(c => c.Origem)
                .HasForeignKey(c => c.OrigemBeaconId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Beacon>()
                .HasMany(b => b.CaminhosDestino)
                .WithOne(c => c.Destino)
                .HasForeignKey(c => c.DestinoBeaconId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
