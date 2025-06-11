using AraviPortal.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AraviPortal.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<City>().HasIndex(x => x.Name).IsUnique();
    }
}