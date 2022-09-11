using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations;

public class OperationClaimEntityTypeConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.HasKey(_operationClaim => _operationClaim.Id);

        builder.Property(_operationClaim => _operationClaim.Name)
            .IsRequired();

        builder.HasData(GenerateSeedDatas());
    }

    public ICollection<OperationClaim> GenerateSeedDatas()
    {
        var operationClaims = new List<OperationClaim>();

        foreach (var value in Enum.GetValues(typeof(OperationClaims)))
        {
            operationClaims.Add(new OperationClaim()
            {
                Id = (int)value,
                Name = ((OperationClaims)value).ToString()
            });
        }

        return operationClaims;
    }
}