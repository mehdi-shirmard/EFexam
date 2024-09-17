using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooManagement.Entities;

namespace ZooManagement.EFPerisistance.Sections;

public class SectionEntityMap : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id)
            .UseIdentityColumn();
    }
}