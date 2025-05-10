using Trainee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicles");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(v => v.Make)
            .HasColumnName("make")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(v => v.Model)
            .HasColumnName("model")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(v => v.Year)
            .HasColumnName("year")
            .IsRequired();

        builder.Property(v => v.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(v => v.Color)
            .HasColumnName("color")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(v => v.Type)
            .HasColumnName("type")
            .HasMaxLength(20)
            .IsRequired();
    }
}