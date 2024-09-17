using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedAt).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedAt).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedAt).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uoc => !uoc.DeletedAt.HasValue);

        builder.HasOne(uoc => uoc.User);
        builder.HasOne(uoc => uoc.OperationClaim);

        builder.HasData(getSeeds());
    }

    private IEnumerable<UserOperationClaim> getSeeds()
    {
        List<UserOperationClaim> userOperationClaims = new();

        UserOperationClaim adminUserOperationClaim = new(id: 1, userId: 1, operationClaimId: 1);
        userOperationClaims.Add(adminUserOperationClaim);

        return userOperationClaims;
    }
}