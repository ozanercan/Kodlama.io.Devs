using Core.Security.Entities.Socials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class UserSocialAccountEntityTypeConfiguration : IEntityTypeConfiguration<UserSocialAccount>
{
    public void Configure(EntityTypeBuilder<UserSocialAccount> builder)
    {
        builder.HasKey(_userSocialAccount => _userSocialAccount.Id);

        builder.Property(_userSocialAccount => _userSocialAccount.Id)
           .HasColumnOrder(0)
           .IsRequired();

        builder.Property(_userSocialAccount => _userSocialAccount.UserId)
           .HasColumnOrder(1)
           .IsRequired();

        builder.Property(_userSocialAccount => _userSocialAccount.SocialPlatformId)
           .HasColumnOrder(2)
           .IsRequired();

        builder.Property(_userSocialAccount => _userSocialAccount.Path)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_userSocialAccount => _userSocialAccount.IsDeleted)
            .HasColumnOrder(4)
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasOne(_userSocialAccount => _userSocialAccount.SocialPlatform)
            .WithMany(_socialPlatform => _socialPlatform.UserSocialAccounts)
            .HasForeignKey(_userSocialAccount => _userSocialAccount.SocialPlatformId);

        builder.HasOne(_userSocialAccount => _userSocialAccount.User)
           .WithMany(_user => _user.UserSocialAccounts)
           .HasForeignKey(_userSocialAccount => _userSocialAccount.UserId);

        builder.HasQueryFilter(_userSocialAccount => _userSocialAccount.IsDeleted == false);
    }
}
