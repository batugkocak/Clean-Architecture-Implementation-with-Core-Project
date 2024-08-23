using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(b=> b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(b => b.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(b => b.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(b => !b.DeletedAt.HasValue);
    }
}