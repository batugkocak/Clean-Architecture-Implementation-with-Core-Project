using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OtpAuthenticatorConfiguration : IEntityTypeConfiguration<OtpAuthenticator>
{
    public void Configure(EntityTypeBuilder<OtpAuthenticator> builder)
    {
        builder.ToTable("OtpAuthenticators").HasKey(oa => oa.Id);

        builder.Property(oa => oa.Id).HasColumnName("Id").IsRequired();
        builder.Property(oa => oa.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(oa => oa.SecretKey).HasColumnName("SecretKey").IsRequired();
        builder.Property(oa => oa.IsVerified).HasColumnName("IsVerified").IsRequired();
        builder.Property(oa => oa.CreatedAt).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oa => oa.UpdatedAt).HasColumnName("UpdatedDate");
        builder.Property(oa => oa.DeletedAt).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oa => !oa.DeletedAt.HasValue);

        builder.HasOne(oa => oa.User);
    }
}