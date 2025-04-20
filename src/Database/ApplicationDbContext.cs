using Microsoft.EntityFrameworkCore;
using Src.Models;

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
        .HasOne(m => m.Sector)
        .WithMany(s => s.Motos)
        .HasForeignKey(m => m.SectorId);


        modelBuilder.Entity<Sector>()
            .HasOne(s => s.Patio)
            .WithMany(p => p.Sectors)
            .HasForeignKey(s => s.PatioId);

        modelBuilder.Entity<Patio>()
            .HasMany(p => p.Sectors)
            .WithOne(s => s.Patio)
            .HasForeignKey(s => s.PatioId);
    }
}