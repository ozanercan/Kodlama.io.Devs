using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(_user => _user.Id);

        builder.Property(_user => _user.FirstName)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_user => _user.LastName)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_user => _user.Email)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_user => _user.PasswordSalt)
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(_user => _user.PasswordHash)
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(_user => _user.Status)
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(_user => _user.AuthenticatorType)
            .HasColumnOrder(7)
            .IsRequired();
    }
}
