using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class UserOperationClaimEntityTypeConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.HasKey(_userOperationClaim => _userOperationClaim.Id);

        builder.HasOne(_userOperationClaim => _userOperationClaim.User)
            .WithMany(_user => _user.UserOperationClaims)
            .HasForeignKey(_userOperationClaim => _userOperationClaim.UserId);

        builder.HasOne(_userOperationClaim => _userOperationClaim.OperationClaim)
            .WithMany(_operationClaim => _operationClaim.UserOperationClaims)
            .HasForeignKey(_userOperationClaim => _userOperationClaim.OperationClaimId);
    }
}