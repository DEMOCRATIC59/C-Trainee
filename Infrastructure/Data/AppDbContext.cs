using Microsoft.EntityFrameworkCore;
using Trainee.Domain.Entities;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Make).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });
    }
}