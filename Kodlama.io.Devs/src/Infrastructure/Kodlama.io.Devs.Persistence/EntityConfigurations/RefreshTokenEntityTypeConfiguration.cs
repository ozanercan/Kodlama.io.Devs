using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(_refreshToken => _refreshToken.Id);

        builder.Property(_refreshToken => _refreshToken.Token)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_refreshToken => _refreshToken.Expires)
           .HasColumnOrder(2)
           .IsRequired();

        builder.Property(_refreshToken => _refreshToken.Created)
          .HasColumnOrder(3)
          .IsRequired();

        builder.Property(_refreshToken => _refreshToken.CreatedByIp)
          .HasColumnOrder(4)
          .IsRequired();

        builder.Property(_refreshToken => _refreshToken.Revoked)
         .HasColumnOrder(5)
         .IsRequired(false);

        builder.Property(_refreshToken => _refreshToken.RevokedByIp)
         .HasColumnOrder(6)
         .IsRequired(false);

        builder.Property(_refreshToken => _refreshToken.ReplacedByToken)
         .HasColumnOrder(7)
         .IsRequired(false);

        builder.HasOne(_refreshToken => _refreshToken.User)
            .WithMany(_user => _user.RefreshTokens)
            .HasForeignKey(_refreshToken => _refreshToken.UserId);
    }
}
