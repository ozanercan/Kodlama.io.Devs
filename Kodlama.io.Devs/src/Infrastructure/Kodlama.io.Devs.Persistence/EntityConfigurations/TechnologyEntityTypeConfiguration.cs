using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class TechnologyEntityTypeConfiguration : IEntityTypeConfiguration<Technology>
{
    public void Configure(EntityTypeBuilder<Technology> builder)
    {
        builder.ToTable("Technology");

        builder.HasKey(_technology => _technology.Id);

        builder.Property(_technology => _technology.Name)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_technology => _technology.IsDeleted)
            .HasColumnOrder(2)
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasQueryFilter(_technology => _technology.IsDeleted == false);
    }
}
