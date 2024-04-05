using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>

{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: u => u.Email, name: "UK_Users_Email").IsUnique();

        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.EmailAuthenticators);
        builder.HasMany(u => u.OtpAuthenticators);

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<User> GetSeeds()
    {
        var users = new List<User>();

        HashingHelper.CreatePasswordHash(
            password: "Passw0rd",
            passwordHash: out var passwordHash,
            passwordSalt: out var passwordSalt
        );

        var adminUser = new User()
        {
            Id = 1,
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@admin.com",
            Status = true,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            AuthenticatorType = AuthenticatorType.None,
        };

        users.Add(adminUser);

        return users;
    }
}
