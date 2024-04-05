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
        builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: uoc => new { uoc.UserId, uoc.OperationClaimId },
            name: "UK_UserOperationClaims_UserId_OperationClaimId").IsUnique();

        builder.HasOne(uoc => uoc.User);
        builder.HasOne(uoc => uoc.OperationClaim);

        builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<UserOperationClaim> GetSeeds()
    {
        var userOperationClaims = new List<UserOperationClaim>();

        var adminUserOperationClaim = new UserOperationClaim()
        {
            Id = 1,
            UserId = 1,
            OperationClaimId = 1
        };

        userOperationClaims.Add(adminUserOperationClaim);

        return userOperationClaims;
    }
}
