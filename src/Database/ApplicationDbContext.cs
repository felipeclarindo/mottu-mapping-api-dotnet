using Microsoft.EntityFrameworkCore;
using Src.Models;

namespace Src.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Patio> Patios { get; set; }
        public DbSet<Sector> Sectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relações
            modelBuilder.Entity<Moto>()
                .HasOne<Sector>()
                .WithMany()
                .HasForeignKey(m => m.SectorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sector>()
                .HasOne<Patio>()
                .WithMany()
                .HasForeignKey(s => s.PatioId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===== SEED DATA =====

            // 1. Patios
            modelBuilder.Entity<Patio>().HasData(
                new Patio { Id = 1, Name = "Patio Central" },
                new Patio { Id = 2, Name = "Patio Lateral" }
            );

            // 2. Sectors (ligados aos patios)
            modelBuilder.Entity<Sector>().HasData(
                new Sector { Id = 1, Name = "Sector A", PatioId = 1 },
                new Sector { Id = 2, Name = "Sector B", PatioId = 1 },
                new Sector { Id = 3, Name = "Sector C", PatioId = 2 }
            );

            // 3. Motos (ligadas aos sectors)
            modelBuilder.Entity<Moto>().HasData(
                new Moto { Id = 1, Plate = "ABC-1234", SectorId = 1 },
                new Moto { Id = 2, Plate = "XYZ-5678", SectorId = 2 },
                new Moto { Id = 3, Plate = "LMN-9999", SectorId = 3 }
            );
        }
    }
}
