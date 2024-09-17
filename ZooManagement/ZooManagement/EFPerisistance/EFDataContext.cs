using Microsoft.EntityFrameworkCore;
using ZooManagement.EFPerisistance.Zoos;
using ZooManagement.Entities;

namespace ZooManagement.EFPerisistance;

public class EfDataContext : DbContext
{
    public DbSet<Zoo> Zoos { get; set; }
    public DbSet<Section> sections { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;" +
                                    "Initial Catalog= TestEFSherkat;" +
                                    "Integrated Security=true;" +
                                    "Trust Server Certificate=true;");
    }
    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(
                typeof(ZooEntityMap).Assembly);
    }
    
}