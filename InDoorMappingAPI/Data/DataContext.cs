using InDoorMappingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Acessibilidade> Acessibilidades { get; set; }
        public DbSet<Beacon> Beacons { get; set; }
        public DbSet<Caminho> Caminhos { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Mobilidade> Mobilidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Infraestrutura> Infraestruturas { get; set; }
        public DbSet<ComandoEpoc> ComandosEpoc { get; set; }
        public DbSet<Diario> Diario { get; set; }
        public DbSet<FeedbackCaminho> FeedbackCaminhos { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; } 
        public DbSet<RecoveryToken> RecoveryTokens { get; set; } 


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=tassi-t1-5318.jxf.gcp-europe-west1.cockroachlabs.cloud;Port=26257;Userid=1240605;Password=AdminDB;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;SslMode=Disable;Database=defaultdb;SSL Mode=Require");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

        }
    }
}
