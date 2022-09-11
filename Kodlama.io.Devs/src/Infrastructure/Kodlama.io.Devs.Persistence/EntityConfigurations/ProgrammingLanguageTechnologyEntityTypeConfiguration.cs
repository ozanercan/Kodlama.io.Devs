using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class ProgrammingLanguageTechnologyEntityTypeConfiguration : IEntityTypeConfiguration<ProgrammingLanguageTechnology>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguageTechnology> builder)
    {
        builder.ToTable("ProgrammingLanguageTechnologies");

        builder.Property(_programmingLanguageTechnology => _programmingLanguageTechnology.Id)
            .HasColumnOrder(0);

        builder.Property(_programmingLanguageTechnology => _programmingLanguageTechnology.ProgrammingLanguageId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.HasOne(_programmingLanguageTechnology => _programmingLanguageTechnology.ProgrammingLanguage)
            .WithMany(_programmingLanguage => _programmingLanguage.ProgrammingLanguageTechnologies)
            .HasForeignKey(_programmingLanguageTechnology => _programmingLanguageTechnology.ProgrammingLanguageId);
    }
}
