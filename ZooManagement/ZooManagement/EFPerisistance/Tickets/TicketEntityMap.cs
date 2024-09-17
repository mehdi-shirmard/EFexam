using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooManagement.Entities;

namespace ZooManagement.EFPerisistance.Tickets;

public class TicketEntityMap : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id)
            .UseIdentityColumn();
    }
}