using AraviPortal.Shared.Entities;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<City>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Hangar>().HasIndex(x => new { x.CityId, x.Name }).IsUnique();
        modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

        // Relación 1 a 1 entre Question y CorrectAnswer
        modelBuilder.Entity<Question>()
            .HasOne(q => q.CorrectAnswer)
            .WithOne(ca => ca.Question)
            .HasForeignKey<CorrectAnswer>(ca => ca.QuestionId)
            .IsRequired(); // Una pregunta DEBE tener una respuesta correcta

        // Para la consistencia de CorrectAnswer (simulando CHECK constraint)
        // Aunque los CHECK constraints a otras tablas no son directamente soportados en EF Core migrations,
        // podemos modelar las relaciones y luego aplicar lógica de validación en la aplicación.
        modelBuilder.Entity<CorrectAnswer>()
            .HasOne(ca => ca.Option)
            .WithMany() // No es una colección en Option, es una referencia de FK
            .HasForeignKey(ca => ca.OptionId)
            .IsRequired(false); // OptionId puede ser NULL

        // Si necesitas mapear el enum QuestionType a string en la base de datos
        modelBuilder.Entity<Question>()
            .Property(q => q.QuestionType)
            .HasConversion<string>(); // Almacena el enum como string (ej. "FalsoVerdadero")

        // Restricción única para QuestionId en CorrectAnswer, similar a UQ_PreguntaRespuesta
        modelBuilder.Entity<CorrectAnswer>()
            .HasIndex(ca => ca.QuestionId)
            .IsUnique();

        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationships)
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}