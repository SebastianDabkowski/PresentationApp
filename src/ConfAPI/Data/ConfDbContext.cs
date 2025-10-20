using Microsoft.EntityFrameworkCore;
using ConfApp.Shared.Models;

namespace ConfAPI.Data;

public class ConfDbContext : DbContext
{
    public ConfDbContext(DbContextOptions<ConfDbContext> options) : base(options)
    {
    }

    public DbSet<Presentation> Presentations { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<Question>()
            .HasOne<Presentation>()
            .WithMany(p => p.Questions)
            .HasForeignKey(q => q.PresentationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Rating>()
            .HasOne<Presentation>()
            .WithMany(p => p.Ratings)
            .HasForeignKey(r => r.PresentationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seed some sample data
        modelBuilder.Entity<Presentation>().HasData(
            new Presentation
            {
                Id = 1,
                Title = "Introduction to Blazor",
                Speaker = "John Doe",
                Description = "Learn the basics of Blazor web framework",
                StartTime = DateTime.Now.AddDays(1),
                EndTime = DateTime.Now.AddDays(1).AddHours(1),
                Room = "Room A"
            },
            new Presentation
            {
                Id = 2,
                Title = "Advanced C# Patterns",
                Speaker = "Jane Smith",
                Description = "Deep dive into modern C# design patterns",
                StartTime = DateTime.Now.AddDays(1).AddHours(2),
                EndTime = DateTime.Now.AddDays(1).AddHours(3),
                Room = "Room B"
            }
        );
    }
}
