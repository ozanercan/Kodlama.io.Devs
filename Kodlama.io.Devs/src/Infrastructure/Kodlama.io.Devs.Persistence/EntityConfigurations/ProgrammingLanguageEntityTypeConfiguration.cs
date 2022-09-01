using Kodlama.io.Devs.Application.Constants;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class ProgrammingLanguageEntityTypeConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
        builder.HasKey(_programmingLanguage => _programmingLanguage.Id);

        builder.Property(_programmingLanguage => _programmingLanguage.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_programmingLanguage => _programmingLanguage.Name)
            .HasColumnOrder(1)
            .HasMaxLength(EntityColumnLimits.ProgrammingLanguageNameMaxLength)
            .IsRequired();

        builder.Property(_programmingLanguage => _programmingLanguage.CreatedDate)
           .HasColumnOrder(2)
           .IsRequired();

        builder.Property(_programmingLanguage => _programmingLanguage.DeletedDate)
           .HasColumnOrder(3)
           .IsRequired(false);

        builder.Property(_programmingLanguage => _programmingLanguage.IsDeleted)
           .HasColumnOrder(4)
           .HasDefaultValue(false)
           .IsRequired();

        builder.HasQueryFilter(_programmingLanguage => _programmingLanguage.IsDeleted == false);
    }
}
