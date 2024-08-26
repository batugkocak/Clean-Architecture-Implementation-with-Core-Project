using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(c => c.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(c => c.CarState).HasColumnName("State");
        builder.Property(c => c.ModelYear).HasColumnName("ModelYear");
        
        builder.Property(c => c.CreatedAt).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedAt).HasColumnName("DeletedDate");

        builder.HasOne(b => b.Model);

        builder.HasQueryFilter(c => !c.DeletedAt.HasValue);
    }
}