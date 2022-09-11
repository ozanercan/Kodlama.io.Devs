using Core.Security.Entities.Socials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class SocialPlatformEntityTypeConfiguration : IEntityTypeConfiguration<SocialPlatform>
{
    public void Configure(EntityTypeBuilder<SocialPlatform> builder)
    {
        builder.HasKey(_socialPlatform => _socialPlatform.Id);

        builder.Property(_socialPlatform => _socialPlatform.Name)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_socialPlatform => _socialPlatform.Url)
            .HasColumnOrder(2)
            .IsRequired();

        builder.HasData(GetSocialPlatformSeedDatas());
    }

    private ICollection<SocialPlatform> GetSocialPlatformSeedDatas()
    {
        var socialPlatforms = new List<SocialPlatform>()
        {
            new SocialPlatform(){ Id = 1, Name = "Github", Url = "https://github.com/"},
            new SocialPlatform(){ Id = 2, Name = "Facebook", Url = "https://facebook.com/"}
        };

        return socialPlatforms;
    }
}
