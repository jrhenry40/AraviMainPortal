using AraviPortal.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Hangar> Hangars { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<CorrectAnswer> CorrectAnswers { get; set; }
    public DbSet<SISUcsAmms> SISUcsAmms { get; set; }
    public DbSet<SISWProgram> SISWProgram { get; set; }
    public DbSet<SISWBuyer> SISWBuyer { get; set; }
    public DbSet<SISWSupplier> SISWSupplier { get; set; }
    public DbSet<SISReceiving> SISReceiving { get; set; }
    public DbSet<SISShipping> SISShipping { get; set; }
    public DbSet<SISSummaryAWB> SISSummaryAWB { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<City>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Hangar>().HasIndex(x => new { x.CityId, x.Name }).IsUnique();
        modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

        modelBuilder.Entity<Question>()
            .HasOne(q => q.CorrectAnswer)
            .WithOne(ca => ca.Question)
            .HasForeignKey<CorrectAnswer>(ca => ca.QuestionId)
            .IsRequired();

        modelBuilder.Entity<CorrectAnswer>()
            .HasOne(ca => ca.Option)
            .WithMany()
            .HasForeignKey(ca => ca.OptionId)
            .IsRequired(false);

        modelBuilder.Entity<Question>()
            .Property(q => q.QuestionType)
            .HasConversion<string>();

        modelBuilder.Entity<CorrectAnswer>()
            .HasIndex(ca => ca.QuestionId)
            .IsUnique();

        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var identityEntityTypes = new HashSet<Type>
        {
            typeof(User),
            typeof(IdentityRole),
            typeof(IdentityUserClaim<string>),
            typeof(IdentityUserLogin<string>),
            typeof(IdentityUserRole<string>),
            typeof(IdentityUserToken<string>),
            typeof(IdentityRoleClaim<string>)
        };

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                bool isIdentityRelated = identityEntityTypes.Contains(foreignKey.PrincipalEntityType.ClrType) ||
                                         identityEntityTypes.Contains(foreignKey.DeclaringEntityType.ClrType);

                if (!isIdentityRelated)
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }
    }
}