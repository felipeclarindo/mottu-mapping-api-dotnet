using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using MotoMappingApiDotnet.Src.Domain.Entities;

namespace MotoMappingApiDotnet.Src.Infra.Database
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
        }
    }
}
