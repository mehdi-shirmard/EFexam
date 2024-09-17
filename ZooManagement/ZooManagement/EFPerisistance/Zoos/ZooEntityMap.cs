using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooManagement.Entities;

namespace ZooManagement.EFPerisistance.Zoos;

public class ZooEntityMap :IEntityTypeConfiguration<Zoo>
{
    public void Configure(EntityTypeBuilder<Zoo> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id)
            .UseIdentityColumn();
        builder.Property(_ => _.Name)
            .IsRequired().HasMaxLength(100);
    }
}