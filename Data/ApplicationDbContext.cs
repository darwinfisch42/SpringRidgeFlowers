using Microsoft.EntityFrameworkCore;
using SpringRidgeFlowers.Data.Entities;

namespace SpringRidgeFlowers.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Plant> Plants => Set<Plant>();
    public DbSet<PlantImage> PlantImages => Set<PlantImage>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<PlantCategory> PlantCategories => Set<PlantCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Plant configuration
        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasIndex(p => p.CommonName);
            entity.HasIndex(p => p.IsActive);
            entity.HasIndex(p => p.IsFloridaNative);

            entity.HasOne(p => p.Stock)
                  .WithOne(s => s.Plant)
                  .HasForeignKey<Stock>(s => s.PlantId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // PlantImage configuration
        modelBuilder.Entity<PlantImage>(entity =>
        {
            entity.HasIndex(pi => pi.PlantId);

            entity.HasOne(pi => pi.Plant)
                  .WithMany(p => p.Images)
                  .HasForeignKey(pi => pi.PlantId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // PlantCategory (many-to-many join)
        modelBuilder.Entity<PlantCategory>(entity =>
        {
            entity.HasKey(pc => new { pc.PlantId, pc.CategoryId });

            entity.HasOne(pc => pc.Plant)
                  .WithMany(p => p.PlantCategories)
                  .HasForeignKey(pc => pc.PlantId);

            entity.HasOne(pc => pc.Category)
                  .WithMany(c => c.PlantCategories)
                  .HasForeignKey(pc => pc.CategoryId);
        });

        // Category configuration
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(c => c.Slug).IsUnique();
        });
    }
}
